﻿using INOM.Support;
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace INOM.Entities
{
    /// <summary>
    /// enum to differentiate 2 types of error, execution time = 1 or errors that autogenerated 
    /// by not fulfilling requirements of the process flow = 2.
    /// 1=execution exception
    /// 2=generated by the bussiness because it meets some requirement
    /// </summary>
    public enum EnumErrorCode
    {
        NONE = 0,
        OMS0001 = 1,
        OMS0002 = 2,
        OMS0003 = 3,
        OMS0004 = 4,
        OMS0005 = 5,
        OMS0006 = 6,
        OMS0007 = 7,
        OMS0008 = 8,
        OMS0009 = 9,
        OMS0010 = 10,
        OMS0011 = 11,
        OMS0012 = 12,
        OMS0013 = 13,
        OMS0014 = 14,
        OMS0015 = 15,
        OMS0016 = 16,
        OMS0017 = 17,
        OMS0018 = 18,
        OMS0019 = 19,
        OMS0020 = 20,
        OMS0021 = 21,
        OMS0022 = 22,
        OMS0023 = 23,
        OMS0024 = 24,
        OMS0025 = 25,
        OMS0026 = 26,
        OMS0027 = 27,
        OMS0028 = 28,
        OMS0029 = 29,
        OMS0030 = 30,
        OMS0031 = 31,
        OMS0032 = 32,
        OMS0033 = 33,
        OMS0034 = 34,
        OMS0035 = 35,
        OMS0036 = 36,
        OMS0037 = 37,
        OMS0038 = 38,
        OMS0039 = 39,
        OMS0040 = 40,
        OMS0041 = 41,
        OMS0042 = 42,
        OMS0043 = 43,
        OMS0044 = 44,
        OMS0045 = 45,
        OMS0046 = 46,
        OMS0047 = 47,
        OMS0048 = 48,
        OMS0049 = 49,
        OMS0050 = 50,

        //SecurityStat Currency OrderType TimeInForce SecurityType
        /// <summary>
        /// El instrumento se encuentra desactivado para operar
        /// </summary>
        OMS0100 = 100,
        /// <summary>
        /// El instrumento no opera con esa moneda
        /// </summary>
        OMS0101 = 101,
        /// <summary>
        /// El instrumento no opera con ese tipo de orden
        /// </summary>
        OMS0102 = 102,
        /// <summary>
        /// El instrumento no opera con ese TimeInForce
        /// </summary>
        OMS0103 = 103,
        /// <summary>
        /// El instrumento no opera con ese SecurityType
        /// </summary>
        OMS0104 = 104,
        /// <summary>
        /// El instrumento no opera con ese SettlmntTyp
        /// </summary>
        OMS0105 = 105,
        /// <summary>
        /// No se pudo obtener la lista de instrumentos para insertar en la tabla InstrumentsByma
        /// </summary>
        OMS0106 = 106,

        OMS9999 = 9999,
    };
    /// <summary>
    /// enum to differentiate 2 types of error, execution time = 1 or errors that autogenerated 
    /// by not fulfilling requirements of the process flow = 2.
    /// 1=execution exception
    /// 2=generated by the bussiness because it meets some requirement
    /// </summary>
    public enum EnumErrorType
    {
        Exception = 1,
        GeneretedException = 2
    };
    /// <summary>
    /// this class works with State Error
    /// A = active
    /// C = cancelede
    /// R = Resolved
    /// </summary>
    public class OrderErrorState
    {
        public const string Active = "A";
        public const string Canceled = "C";
        public const string Resolved = "R";
    }
    /// <summary>
    /// class that registers errors, at runtime and due to logic errors
    // /to runtime errors, the json of ErrorException is saved
    /// </summary>
    public class ErrorLog
    {
        /// <summary>
        /// Error id is indexed from to 1
        /// </summary>
        [Key]
        public int ErrorLogID { get; set; }
        /// <summary>
        /// component where the error occurs
        /// </summary>
        public string ComponentSource  { get; set; }
        /// <summary>
        ///The error message may be the one generated by an exception
        ///of.net or custom, that is, a validation that does not meet any requirement
        /// </summary>
        [StringLength(200)]
        public string ErrorMessage { get; set; }
        /// <summary>
        /// 1=execution exception
        /// 2=generated by the bussiness because it meets some requirement
        /// </summary>
        public int ErrorType { get; set; }
        /// <summary>
        /// Error Code of the error occurred
        /// </summary>
        public string ErrorCode { get; set; }
        /// <summary>
        ///serialized json object of the exception, it is only completed if there was an exception
        ///if not put NULL
        /// </summary>
        [NotMapped]
        public Exception ErrorExceptionObj { get; set; }

        [StringLength(200)]
        public string ErrorExceptionMessage{ get; set; }
        /// <summary>
        /// ComponentTarget
        /// </summary>
        [StringLength(100)]
        public string ComponentTarget	{ get; set; }
        /// <summary>
        /// MarketOrderID
        /// </summary>
        public int MarketOrderID	 { get; set; }
        /// <summary>
        /// MarketTradeID
        /// </summary>
        public int MarketTradeID	{ get; set; }
        /// <summary>
        /// OrderID
        /// </summary>
        public int OrderID  { get; set; }

        /// <summary>
        /// InstructionID
        /// </summary>
        public int InstructionID { get; set; }

        /// <summary>
        /// StackTrace
        /// </summary>
        [MaxLength(5000)]
        public string StackTrace { get; set; }
        /// <summary>
        /// ProcedureName
        /// </summary>
        [MaxLength(200)]
        public string ProcedureName { get; set; }

        /// <summary>
        /// momento del error
        /// </summary>
        public DateTime When   { get; set; }
        /// <summary>
        /// The error state
        /// OrderErrorState.Active  = A
        /// OrderErrorState.Canceled = C
        /// OrderErrorState.Resolved = C
        /// use this class to write: OrderErrorState
        /// </summary>
        public string ErrorState { get; set; }

        public int? Retries { get; set; }
        public DateTime? UpdateDate { get; set; }


        /// <summary>
        /// overload of the save with more parameters
        /// </summary>
        /// <param name="OrderID"></param>
        /// <param name="ComponentSource"></param>
        /// <param name="ErrorMessage"></param>
        /// <param name="ComponentTarget"></param>
        public static void Save(int OrderID, string ComponentSource, string ErrorMessage, EnumErrorCode ErrorCode, string ComponentTarget,int MarketOrderId,int MarketTradeId, [System.Runtime.CompilerServices.CallerMemberName] string ProcedureName = "")
        {          
            Save(ComponentSource,ErrorMessage, ErrorCode.ToString(), LogError.ReadErrorDescription(ErrorCode.ToString()), null, ComponentTarget, OrderID,  MarketOrderId, MarketTradeId,0, ProcedureName);
        }

        /// <summary>
        /// overload of the save with more parameters
        /// </summary>
        /// <param name="OrderID"></param>
        /// <param name="ComponentSource"></param>
        /// <param name="ErrorMessage"></param>
        /// <param name="ComponentTarget"></param>
        public static void Save(string ComponentSource, string ErrorMessage, EnumErrorCode ErrorCode, string ComponentTarget)
        {
            Save(ComponentSource, ErrorMessage, ErrorCode.ToString(), LogError.ReadErrorDescription(ErrorCode.ToString()), null,  ComponentTarget);
        }

        /// <summary>
        /// We log the error, if the error is an system exception we have 
        /// to serialize the field ErrorException ,if not we don't write any
        /// </summary>
        /// <param name="OrderID"></param>
        /// <param name="ComponentSource"></param>
        /// <param name="ErrorMessage"></param>
        /// <param name="ErrorException"></param>
        /// <param name="ComponentTarget"></param>
        /// <param name="MarketOrderID"></param>
        /// <param name="MarketTradeID"></param>
        /// <param name="ErrorType"></param>
        /// <param name="Retries"></param>
        /// <param name="UpdateDate"></param>
        public static void Save(int OrderID, string ComponentSource,  string ErrorMessage, EnumErrorCode ErrorCode, Exception oException, string ComponentTarget, int MarketOrderID = 0, int MarketTradeID = 0, [System.Runtime.CompilerServices.CallerMemberName] string ProcedureName = "")
        {
            Save(ComponentSource, ErrorMessage, ErrorCode.ToString(), LogError.ReadErrorDescription(ErrorCode.ToString()), oException, ComponentTarget, OrderID,  MarketOrderID, MarketTradeID, 0,ProcedureName);
        }
        public static void Save(int OrderID, string ComponentSource, string ErrorMessage, EnumErrorCode ErrorCode, Exception oException, string ComponentTarget, int MarketOrderID, int MarketTradeID, int InstructionID, [System.Runtime.CompilerServices.CallerMemberName] string ProcedureName = "")
        {
            Save(ComponentSource, ErrorMessage, ErrorCode.ToString(), LogError.ReadErrorDescription(ErrorCode.ToString()), null, ComponentTarget, OrderID, MarketOrderID, MarketTradeID, InstructionID, ProcedureName);
        }
        public static void Save(int OrderID, string ComponentSource, string ErrorMessage, string ErrorCode, Exception oException, string ComponentTarget, int MarketOrderID, int MarketTradeID, int InstructionID, [System.Runtime.CompilerServices.CallerMemberName] string ProcedureName = "")
        {
            Save(ComponentSource, ErrorMessage, ErrorCode.ToString(), ErrorMessage, null, ComponentTarget, OrderID, MarketOrderID, MarketTradeID, InstructionID, ProcedureName);
        }
        /// <summary>
        /// We log the error, if the error is an system exception we have 
        /// to serialize the field ErrorException ,if not we don't write any
        /// </summary>
        private static void Save(string ComponentSource, string ErrorMessage, string ErrorCode,string ErrorDescription, Exception oException, string ComponentTarget, int OrderID = 0, int MarketOrderID = 0, int MarketTradeID = 0, int InstructionID = 0, [System.Runtime.CompilerServices.CallerMemberName] string ProcedureName = "")
        {
            ErrorLog oErrorLog = new ErrorLog();
           
            oErrorLog.OrderID = OrderID;

            oErrorLog.InstructionID = InstructionID;

            oErrorLog.ComponentSource = ComponentSource;

            //error message used when a user generated error occurs
            oErrorLog.ErrorMessage = ErrorDescription;

            oErrorLog.ErrorCode = ErrorCode;

            oErrorLog.ErrorExceptionMessage = ErrorMessage;

            oErrorLog.ComponentTarget = ComponentTarget;

            // on error creation always set to Active to indicate pending action required.
            oErrorLog.ErrorState = OrderErrorState.Active;

            oErrorLog.MarketOrderID = MarketOrderID;

            oErrorLog.MarketTradeID = MarketTradeID;

            oErrorLog.When = DateTime.Now;

            oErrorLog.ErrorExceptionObj = oException;

            oErrorLog.ProcedureName = ProcedureName;

            if (oException != null)
            {
                oErrorLog.ErrorType = (int)EnumErrorType.Exception;

                //------------------------------------------------------------------------------------------
                //validar tamaño de StackTrace
                if (oException.StackTrace.Length > 5000)
                    oErrorLog.StackTrace = oException.StackTrace.Substring(0, 4999);
                else
                    oErrorLog.StackTrace = oException.StackTrace;
                //------------------------------------------------------------------------------------------

                //------------------------------------------------------------------------------------------
                //validar tamaño deL mensaje de error
                if (oException.Message.Length > 200)
                    oErrorLog.ErrorExceptionMessage = oException.Message.Substring(0, 199);
                else
                    oErrorLog.ErrorExceptionMessage = oException.Message;
                //------------------------------------------------------------------------------------------


                oErrorLog.ErrorType = (int)EnumErrorType.Exception;
            }
            else
            {
                oErrorLog.ErrorType = (int)EnumErrorType.GeneretedException;
            }

            // Add a new error
            using (var db = new DBContext())
            {
                db.ErrorLogs.Add(oErrorLog);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// when the error process resolver works, there are
        /// 3 possibilities, Resolved when are success in the resolution
        /// Cancelled , where is not posible to resolve and active
        /// that is posible to resolve but not now, in that case
        /// we increment the the retries and, update the UpdateDate.
        /// </summary>
        /// <param name="ErrorLogID"></param>
        /// <param name="error_state"></param>
        public static void ReProcessErrors(int ErrorLogID,string error_state)
        {
            using (var db = new DBContext())
            {
                var _update = (from p in db.ErrorLogs
                                 where p.ErrorLogID == ErrorLogID
                               select p).SingleOrDefault();
                
                if(error_state == OrderErrorState.Active)
                {
                    _update.Retries += 1;
                    _update.UpdateDate = DateTime.Now;
                }
                else
                {
                    _update.ErrorState = error_state;
                }
                db.SaveChanges();
            }
        }
        #region manejo de objetos de error cancelado
        //private static string ObjectErrorToString(ref ErrorLog oErrorLog)
        //{
        //    var ex = oErrorLog.ErrorExceptionObj;
        //    string ExceptionToString = string.Empty;

        //    string typeOfException = ex.GetType().ToString();
        
        //    switch (typeOfException)
        //    {
        //        case "ArgumentException":

        //            DataContractJsonSerializer ArgumentException = new DataContractJsonSerializer(typeof(System.ArgumentException));
        //            MemoryStream ms1 = new MemoryStream();
        //            ArgumentException.WriteObject(ms1, ex);
        //            ms1.Position = 0;
        //            StreamReader sri = new StreamReader(ms1);
        //            ExceptionToString = sri.ReadToEnd();

        //            break;
        //        case "ArgumentNullException":
        //            DataContractJsonSerializer ArgumentNullException = new DataContractJsonSerializer(typeof(System.ArgumentNullException));
        //            MemoryStream ms2 = new MemoryStream();
        //            ArgumentNullException.WriteObject(ms2, ex);
        //            ms2.Position = 0;
        //            StreamReader sri2 = new StreamReader(ms2);
        //            ExceptionToString = sri2.ReadToEnd();
        //            break;
        //        case "ArgumentOutOfRangeException":
        //            DataContractJsonSerializer ArgumentOutOfRangeException = new DataContractJsonSerializer(typeof(System.ArgumentException));
        //            MemoryStream ms3 = new MemoryStream();
        //            ArgumentOutOfRangeException.WriteObject(ms3, ex);
        //            ms3.Position = 0;
        //            StreamReader sri3 = new StreamReader(ms3);
        //            ExceptionToString = sri3.ReadToEnd();
        //            break;
        //        case "DirectoryNotFoundException":
        //            DataContractJsonSerializer DirectoryNotFoundException = new DataContractJsonSerializer(typeof(DirectoryNotFoundException));
        //            MemoryStream ms4 = new MemoryStream();
        //            DirectoryNotFoundException.WriteObject(ms4, ex);
        //            ms4.Position = 0;
        //            StreamReader sri4 = new StreamReader(ms4);
        //            ExceptionToString = sri4.ReadToEnd(); break;
        //        case "System.DivideByZeroException":
                    
        //            DataContractJsonSerializer DivideByZeroException = new DataContractJsonSerializer(typeof(System.DivideByZeroException));
        //            MemoryStream ms5 = new MemoryStream();
        //            DivideByZeroException.WriteObject(ms5, ex);
        //            ms5.Position = 0;
        //            StreamReader sri5 = new StreamReader(ms5);
        //            ExceptionToString = sri5.ReadToEnd();
                    
        //            break;
        //        case "DriveNotFoundException":
        //            DataContractJsonSerializer DriveNotFoundException = new DataContractJsonSerializer(typeof(DriveNotFoundException));
        //            MemoryStream ms6 = new MemoryStream();
        //            DriveNotFoundException.WriteObject(ms6, ex);
        //            ms6.Position = 0;
        //            StreamReader sri6 = new StreamReader(ms6);
        //            ExceptionToString = sri6.ReadToEnd();
        //            break;
        //        case "FileNotFoundException":
        //            DataContractJsonSerializer FileNotFoundException = new DataContractJsonSerializer(typeof(FileNotFoundException));
        //            MemoryStream ms7 = new MemoryStream();
        //            FileNotFoundException.WriteObject(ms7, ex);
        //            ms7.Position = 0;
        //            StreamReader sri7 = new StreamReader(ms7);
        //            ExceptionToString = sri7.ReadToEnd();
        //            break;
        //        case "FormatException":
        //            DataContractJsonSerializer FormatException = new DataContractJsonSerializer(typeof(System.FormatException));
        //            MemoryStream ms8 = new MemoryStream();
        //            FormatException.WriteObject(ms8, ex);
        //            ms8.Position = 0;
        //            StreamReader sri8 = new StreamReader(ms8);
        //            ExceptionToString = sri8.ReadToEnd(); break;
        //        case "IndexOutOfRangeException":
        //            DataContractJsonSerializer IndexOutOfRangeException = new DataContractJsonSerializer(typeof(System.IndexOutOfRangeException));
        //            MemoryStream ms9 = new MemoryStream();
        //            IndexOutOfRangeException.WriteObject(ms9, ex);
        //            ms9.Position = 0;
        //            StreamReader sri9 = new StreamReader(ms9);
        //            ExceptionToString = sri9.ReadToEnd();
        //            break;
        //        case "InvalidOperationException":
        //            DataContractJsonSerializer InvalidOperationException = new DataContractJsonSerializer(typeof(System.InvalidOperationException));
        //            MemoryStream ms10 = new MemoryStream();
        //            InvalidOperationException.WriteObject(ms10, ex);
        //            ms10.Position = 0;
        //            StreamReader sri10 = new StreamReader(ms10);
        //            ExceptionToString = sri10.ReadToEnd();
        //            break;
        //        case "NotImplementedException":
        //            DataContractJsonSerializer NotImplementedException = new DataContractJsonSerializer(typeof(System.NotImplementedException));
        //            MemoryStream ms11 = new MemoryStream();
        //            NotImplementedException.WriteObject(ms11, ex);
        //            ms11.Position = 0;
        //            StreamReader sri11 = new StreamReader(ms11);
        //            ExceptionToString = sri11.ReadToEnd(); break;
        //        case "NotSupportedException":
        //            DataContractJsonSerializer NotSupportedException = new DataContractJsonSerializer(typeof(System.NotSupportedException));
        //            MemoryStream ms12 = new MemoryStream();
        //            NotSupportedException.WriteObject(ms12, ex);
        //            ms12.Position = 0;
        //            StreamReader sri12 = new StreamReader(ms12);
        //            ExceptionToString = sri12.ReadToEnd();
        //            break;
        //        case "ObjectDisposedException":
        //            DataContractJsonSerializer ObjectDisposedException = new DataContractJsonSerializer(typeof(System.ObjectDisposedException));
        //            MemoryStream ms13 = new MemoryStream();
        //            ObjectDisposedException.WriteObject(ms13, ex);
        //            ms13.Position = 0;
        //            StreamReader sri13 = new StreamReader(ms13);
        //            ExceptionToString = sri13.ReadToEnd();
        //            break;
        //        case "OverflowException":
        //            DataContractJsonSerializer OverflowException = new DataContractJsonSerializer(typeof(System.OverflowException));
        //            MemoryStream ms14 = new MemoryStream();
        //            OverflowException.WriteObject(ms14, ex);
        //            ms14.Position = 0;
        //            StreamReader sri14 = new StreamReader(ms14);
        //            ExceptionToString = sri14.ReadToEnd();
        //            break;
        //        case "PathTooLongException":
        //            DataContractJsonSerializer PathTooLongException = new DataContractJsonSerializer(typeof(PathTooLongException));
        //            MemoryStream ms15 = new MemoryStream();
        //            PathTooLongException.WriteObject(ms15, ex);
        //            ms15.Position = 0;
        //            StreamReader sri15 = new StreamReader(ms15);
        //            ExceptionToString = sri15.ReadToEnd(); break;
        //        case "PlatformNotSupportedException":
        //            DataContractJsonSerializer PlatformNotSupportedException = new DataContractJsonSerializer(typeof(System.PlatformNotSupportedException));
        //            MemoryStream ms17 = new MemoryStream();
        //            PlatformNotSupportedException.WriteObject(ms17, ex);
        //            ms17.Position = 0;
        //            StreamReader sri17 = new StreamReader(ms17);
        //            ExceptionToString = sri17.ReadToEnd(); break;
        //        case "RankException":
        //            DataContractJsonSerializer RankException = new DataContractJsonSerializer(typeof(System.RankException));
        //            MemoryStream ms18 = new MemoryStream();
        //            RankException.WriteObject(ms18, ex);
        //            ms18.Position = 0;
        //            StreamReader sri18 = new StreamReader(ms18);
        //            ExceptionToString = sri18.ReadToEnd(); break;
        //        case "TimeoutException":
        //            DataContractJsonSerializer TimeoutException = new DataContractJsonSerializer(typeof(System.TimeoutException));
        //            MemoryStream ms19 = new MemoryStream();
        //            TimeoutException.WriteObject(ms19, ex);
        //            ms19.Position = 0;
        //            StreamReader sri19 = new StreamReader(ms19);
        //            ExceptionToString = sri19.ReadToEnd(); 
        //            break;
        //        case "UriFormatException":
        //            DataContractJsonSerializer UriFormatException = new DataContractJsonSerializer(typeof(System.UriFormatException));
        //            MemoryStream ms20 = new MemoryStream();
        //            UriFormatException.WriteObject(ms20, ex);
        //            ms20.Position = 0;
        //            StreamReader sri20 = new StreamReader(ms20);
        //            ExceptionToString = sri20.ReadToEnd(); 
        //            break;
        //        default:
        //            break;
        //    }

        //    return ExceptionToString;
        //}
        #endregion
    }
}
