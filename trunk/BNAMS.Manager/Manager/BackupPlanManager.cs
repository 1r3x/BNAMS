﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BNAMS.Entities;
using BNAMS.Manager.Common;
using BNAMS.Manager.Interface;

namespace BNAMS.Manager.Manager
{
    public class BackupPlanManager : IBackupPlan
    {

        private readonly ResponseModel _aModel;
        private readonly SmartRecordEntities _db;
        private readonly List<string> _backupList;
        private readonly List<string> _listOfTablesToSearch;

        public BackupPlanManager()
        {
            _backupList = new List<string> {
                "USE BNAMS \n"
                //, "GO \n",
                //"-- Auto generated BackUp\n",
                //$"-- BackUpFrom----{(string)System.Web.HttpContext.Current.Session["directorateId"]}\n",
                //$"-- BackUpBy----{(int?)System.Web.HttpContext.Current.Session["userid"]}\n",
            };
            _db = new SmartRecordEntities();
            _aModel = new ResponseModel();
            _listOfTablesToSearch = new List<string>
            {
                "HR_TraineePersonBio",
                "HR_TraningInformation",
                "I_BinLocation",
                "I_Indent",
                "I_MaintenanceInfo",
                "I_StatusAfterMaintaince",
                "I_WeaponsInfo",
                "M_Agent",
                "M_Authorirty",
                "M_CapabilityOfWeapons",
                "M_Composite",
                "M_Country",
                "M_FiscalYear",
                "M_NameOfWeapon",
                "M_ProcurementCategory",
                "M_ProductCategory",
                "M_QuantityCategory",
                "M_RankSetup",
                "M_StatusInformation",
                "M_WeaponsModelType",
                "O_DirectorateInfo",
                "O_ShipOrDepotInfo",
                "O_WareHouse",
                "W_Inspection"
            };
        }


        


        public string GetFullBackupScript()
        {
            foreach (var t in _listOfTablesToSearch)
            {
                var scripts = $"EXEC [sp_generate_updates] 'select * from {t} where IsBackup=''0''  '";
                var text = _db.Database.SqlQuery<string>(scripts).ToList();
                for (var i = 0; i < text.Count - 3; i++)
                {
                    if (i == 0 || i == 1 || i == 2)
                    {
                        //just skip
                    }
                    else
                    {
                        _backupList.Add(text[i]);
                    }
                }
            }

            return string.Join("", _backupList);
        }

      

        public string UpdateAllIsBackupStatus()
        {
            foreach (var t in _listOfTablesToSearch)
            {
                _db.spSetTabelBackUpStatusToTrue(t);
            }

            return "Data Updated Successfully";

        }


       



    }
}
