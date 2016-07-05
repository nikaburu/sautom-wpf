using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Sautom.Server.Security
{
    [Serializable]
    public sealed class SystemUser
    {
	    private static IEnumerable<SystemUser> _users;
	    public string FullName { get; set; }
	    public string Name { get; set; }
	    public string Password { get; set; }
	    public List<string> Roles { get; set; }

	    public static IEnumerable<SystemUser> Users
        {
            get
            {
                if (_users == null)
                {
                    string filePath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\Users.xml";
                    _users = ReadFromXml(filePath);
                }

                return _users;
            }
        }

	    private static IEnumerable<SystemUser> ReadFromXml(string filePath)
        {
            using (FileStream fs = File.Open(filePath, FileMode.Open))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<SystemUser>));
                return (IEnumerable<SystemUser>)xmlSerializer.Deserialize(fs);
            }
        }
    }

    [Serializable]
    public sealed class SystemUserRoles
    {
	    public const string Administrator = "Administrator";
	    public const string Manager = "Manager";
    }
}
