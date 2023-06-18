using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominCore.Constants
{
    public static class Helper
    {
        public const string FullOwner = "FullOwner";
        public const string EmailFullOwner = "fullOwner@app.com";
        public const string PasswordFullOwner = "123456";



        public const string OwnerCompany = "OwnerCompany";
        public const string EmailOwnerCompany = "ownerCompany@app.com";
        public const string PasswordOwnerCompany = "123456";
        ////
        /// <summary>
        /// 
        /// 
        /// </summary>
        /// 

        public const string BranchManager = "BranchManager";
        public const string EmailBranchManager = "branchManager@app.com";
        public const string PasswordBranchManager = "123456";


        public const string MainCompany = "الشركة الرئيسية";
        public const string EmailMainCompany = "MainCompany@app.com";
        public const string LogoComapny = "LogoCompany.jpg";

        public const string MainBranch = "الفرع الرئيسى ";
        public const string EmailMainBranch = "MainBranch@app.com";
        //MsgType
        public const string msgType = "msgType";
        public const string msg = "msg";
        public const string Success = "Success";
        public const string Error = "Error";

        public const string DefaultUsers  = "DefaultUser.jpg";



        public enum estateTypeUser
        {
            User=0,
            FullOwner=1,
            OwnerCompany=2, 
            BranchManager=3,
        }
       
    }
}
