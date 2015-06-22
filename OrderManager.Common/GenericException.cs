using System;

namespace OrderManager.Common
{


    public class GenericException : Exception
    {

        public GenericException()
        {
            
        }


        private string _message;

        public override string Message
        {
            get
            {
                return _message;
            }
        }

        private string _helpLink;

        public override string HelpLink
        {
            get
            {
                return _helpLink;
            }
            set
            {
                base.HelpLink = value;
            }
        }

     

        public GenericException(Exception ex)
            : base("", ex)
        {
     
        }

        public GenericException(string message)
        {
            _message = message;
         }

        public GenericException(string message, string actionCode)
        {
            _message = message;
            _helpLink = actionCode;
        }

        public GenericException(string message, Exception ex)
            : base(message, ex)
        {
            this._message = message;
        }
    }


}
