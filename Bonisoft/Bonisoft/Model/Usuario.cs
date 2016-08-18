using Bonisoft.Data_Objects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bonisoft.Model
{
    public class Usuario
    {
            #region Properties

            public string id { get; set; }

            public string userName { get; set; }

            public string groupName { get; set; }

            public string password { get; set; }

            public DateTime passwordDate { get; set; }

            public int deleted { get; set; }

            public int disabled { get; set; }

            public DateTime dateCreated { get; set; }

            public DateTime dateDeleted { get; set; }

            public DateTime dateDisabled { get; set; }

            #endregion Properties

            #region Constructors

            public Usuario()
            {
            }

            public Usuario(string userID, string username)
            {
                if (userID != "")
                {
                    id = userID;
                    Fill();
                }
                else if (username != "")
                {
                    userName = username;
                    FillByUserName();
                }
            }

            #endregion Constructors

            #region Fill

            public void Fill()
            {
            UsuarioDAO.Fill(this);
            }

            public void FillByUserName()
            {
            UsuarioDAO.FillByUserName(this);
            }

            #endregion Fill

            #region Methods

            public void Create()
            {
                //OrkprogramDAO.Create(this);
            }

            #endregion Methods

            #region Static Methods

            public static List<Tuple<int, string>> GetUserGroups()
            {
                return UsuarioDAO.GetUserGroups();
            }

            #endregion Static Methods
        }
    }