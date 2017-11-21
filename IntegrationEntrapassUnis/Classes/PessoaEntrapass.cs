using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Advantage.Data.Provider;
using System.Windows.Forms;
using System.Data;

namespace EntrapassUnisIntegration.Classes
{
    class PessoaEntrapass
    {
        //ARGUMENTOS
        AdsConnection adsConnection;

        string serverSource;

        public PessoaEntrapass(string serverSource)
        {
            this.serverSource = serverSource;

          
        }


        public DataTable selectPessoas()
        {
            openConnection(serverSource);

            int iField;
            AdsCommand adsCommand = adsConnection.CreateCommand();
            adsCommand.CommandText = "SELECT * FROM Card";
            AdsDataReader adsDataReader = adsCommand.ExecuteReader();

            DataTable dataTable = new DataTable();
            dataTable.Load(adsDataReader);

            closeConnection();
            return dataTable;

        

        }


        public bool insertPessoas(int pkData, string userName, string creationDate, string cardNumberFormatted, string cardNumber, string startDate, string endDate)
        {
            try
            {
                openConnection(serverSource);

                AdsCommand adsCommand = adsConnection.CreateCommand();
                adsCommand.CommandText = string.Format("INSERT INTO Card " +
                    "(PkData,FkObject,FkParent,MasterAccount,Account,Cluster,NTM,GSI,Site,Info1,Info2,Info3,Info4,State,TransactionId," +
                    "TransactionTag,CardNumberCount,CardNumberFormatted,CardNumber,CardDisplayFormat,UserName,Email,CardInfo1,CardInfo2," +
                    "CardInfo3,CardInfo4,CardInfo5,CardInfo6,CardInfo7,CardInfo8,CardInfo9,CardInfo10,CardInfo11,CardInfo12,CardInfo13," +
                    "CardInfo14,CardInfo15,CardInfo16,CardInfo17,CardInfo18,CardInfo19,CardInfo20,CardInfo21,CardInfo22,CardInfo23,CardInfo24," +
                    "CardInfo25,CardInfo26,CardInfo27,CardInfo28,CardInfo29,CardInfo30,CardInfo31,CardInfo32,CardInfo33,CardInfo34,CardInfo35," +
                    "CardInfo36,CardInfo37,CardInfo38,CardInfo39,CardInfo40,IsTrace,StartDate,UsingEndDate,EndDate,DeleteOnExpired,DeleteWhenExpired," +
                    "PriviledgeOperation,SupervisorLevel,CardState,DeactivateOverall,WaitForKeypad,ItemCount,PictureType,PictureVersion,Picture,ThumbNail," +
                    "SignatureType,SignatureVersion,Signature,FkCardType,FkCardFilter,CardCountState,CardCountValue,CardCountReach,ManualCardCount,ExpiredCardCount," +
                    "DisablePassback,FkBadging,PrintIssue,UseSpecificBarcodeValue,BarcodeValue,ExtendedAccessDelay,DoubleTripleSwipe,CreationDate,ModificationDate," +
                    "ModificationCount,IsNIP,NIPSize,EncryptedNIP,PrintIssueState,PrintIssueStateChanged,FkPrintIssueStateChanged,PrintIssueAddress,ExternalUserID," +
                    "GoPass,GoPassLanguage,GoPassEncryptedPassword,GoPassReference,GoPassPhoneUUID,FkActiveDirectory,LDAPUniqueId,LDAPFieldMapping,IsComment,XMLData)" +
                    " VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}','{9}', '{10}' ,'{11}', '{12}','{13}', '{14}','{15}', '{16}, '{17}', '{18}', " +
                    "'{19}, '{20}', '{21}', '{22}', '{23}', '{24}', '{25}', '{26}', '{27}', '{28}','{29}', '{30}' ,'{31}', '{32}','{33}', '{34}','{35}', '{36}, '{37}', '{38}'," +
                    " '{39}, '{40}', '{41}', '{42}', '{43}', '{44}', '{45}', '{46}', '{47}', '{48}','{49}', '{50}', '{61}', '{62}', '{63}', '{64}', '{65}', '{66}', '{67}', '{68}'," +
                    "'{69}', '{70}', '{71}', '{72}', '{73}', '{74}', '{75}', '{76}', '{77}', '{78}','{79}', '{80}', '{81}', '{82}', '{83}', '{84}', '{85}', '{86}', '{87}', '{88}','{89}'," +
                    " '{90}', '{91}', '{92}', '{93}', '{94}', '{95}', '{96}', '{97}', '{98}','{99}', '{100}', '{101}', '{102}', '{103}', '{104}', '{105}', '{106}', '{107}', '{108}','{109}'," +
                    " '{110}', '{111}', '{112}', '{113}', '{114}', '{115}', '{116}', '{117}');", pkData, 5, 43, 0, 0, 0, 0, 0, 0, pkData, 0, 0, 0, 1, 1, creationDate, 1, cardNumberFormatted, cardNumber, 5, userName, "{}", "{}", 
                    "{}", "{}", "{}", "{}", "{}", "{}", "{}", "{}", "{}", "{}", "{}", "{}", "{}", "{}", "{}", "{}", "{}", "{}", "{}", "{}", "{}", "{}", "{}", "{}", "{}", "{}", "{}",
                    "{}", "{}", "{}", "{}", "{}", "{}", "{}", "{}", "{}", "{}", "{}", "{}", 0, startDate, 0, endDate, 0, 0, 0, 0, 0, 0, 0, 0, 0, "{}", "{}", "{}", "{}", "{}", "{}", 14,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "{}", 0, 0, creationDate, creationDate, 1, 0, 5, "{}", 0, "30/12/1899 00:00:00", 0, 0, 0.0000, 0, 0, "{}", "{}", "{}", 0, "{}", "{}", 0,
                    "<?xml version=\"1.0\" encoding=\"UTF-8\"?><XmlData_Card/>");
                int executeNonQuery = adsCommand.ExecuteNonQuery();

                closeConnection();

                if (executeNonQuery == 1)
                {
                    return true;
                }
                return false;
            }
            catch
            {
                closeConnection();
                return false;
            }

        }

        private bool closeConnection()
        {
            try
            {
                adsConnection.Close();

                return true;
            }
            catch
            {
                return false;
            }
        }

        private bool openConnection(string serverSource)
        {
            try
            {
                //CONEXÃO
                adsConnection = new AdsConnection(string.Format("data source={0};" + "ServerType=remote|local; TableType=ADT", serverSource));

                adsConnection.Open();
                AdsCommand adsCommand = adsConnection.CreateCommand();
                adsCommand.CommandText = "EXECUTE PROCEDURE sp_AllowMultipleCollations('GENERAL_VFP_CI_AS_1252', true );";
                int returnCommand = adsCommand.ExecuteNonQuery();

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
