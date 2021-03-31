using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Security;

namespace ActivosChevy.Models
{
    public class LdapAuthentication
    {
        private string _path;
        private string _filterAttribute;

        private string propertytitle;
        private string propertyDepart;
        private static StringBuilder groupNames = new StringBuilder();

        private string[] InfoPath;
        public string Perfil = string.Empty;
        public string Miembro = string.Empty;
        public LdapAuthentication(string path)
        {
            _path = path;
        }

        public string IsAuthenticated(string domain, string username, string pwd)
        {

            string domainAndUsername = domain + @"\" + username;
            DirectoryEntry entry = new DirectoryEntry(_path, domainAndUsername, pwd);
            FormsAuthentication.SignOut();
            groupNames.Clear();

            try
            {
                object obj = entry.NativeObject;
                DirectorySearcher search = new DirectorySearcher(entry);
                search.Filter = "(SAMAccountName=" + username + ")";
                search.PropertiesToLoad.Add("cn");
                SearchResult result = search.FindOne();
                DirectoryEntry dsresult = result.GetDirectoryEntry();

                if (null == result)
                {
                    Perfil = "N";
                }
                else
                {
                    _path = result.Path;
                    InfoPath = result.Path.Split(',');
                    Perfil = InfoPath[2].ToString();
                    int h = Perfil.IndexOf('=') + 1;
                    int j = Perfil.Length - h;
                    Perfil = Perfil.Substring(h, j);
                    _filterAttribute = (string)result.Properties["cn"][0];
                    //  result = search.FindOne();

                    search.PropertiesToLoad.Add("title");
                    result = search.FindOne();
                    propertytitle = (string)result.Properties["title"][0];

                    search.PropertiesToLoad.Add("department");
                    result = search.FindOne();
                    propertyDepart = (string)result.Properties["department"][0];

                    search.PropertiesToLoad.Add("memberOf");
                    result = search.FindOne();
                    int propertyCount = result.Properties["memberOf"].Count;
                    String dn;
                    int equalsIndex, commaIndex;
                    for (int propertyCounter = 0; propertyCounter < propertyCount;
                    propertyCounter++)
                    {
                        dn = (String)result.Properties["memberOf"][propertyCounter];
                        equalsIndex = dn.IndexOf("=", 1);
                        commaIndex = dn.IndexOf(",", 1);
                        if (-1 == equalsIndex)
                        {
                            return null;
                        }
                        groupNames.Append(dn.Substring((equalsIndex + 1),
                        (commaIndex - equalsIndex) - 1));
                        groupNames.Append("|");

                    }

                    groupNames.Append("(CargoUser=" + propertytitle + ", NameUser=" + _filterAttribute + ", DeptUser=" + propertyDepart + ")");


                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error authenticating user. " + ex.Message);
            }

            return groupNames.ToString();

        }
    }
}