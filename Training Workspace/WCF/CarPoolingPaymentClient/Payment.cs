﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18408
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SelfHostingServicePaymentLibraray
{
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="CreditCard", Namespace="http://schemas.datacontract.org/2004/07/SelfHostingServicePaymentLibraray")]
    public partial class CreditCard : object, System.Runtime.Serialization.IExtensibleDataObject
    {
        
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private string CCNoField;
        
        private System.DateTime ExpDateField;
        
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string CCNo
        {
            get
            {
                return this.CCNoField;
            }
            set
            {
                this.CCNoField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime ExpDate
        {
            get
            {
                return this.ExpDateField;
            }
            set
            {
                this.ExpDateField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="CreditCardException", Namespace="http://schemas.datacontract.org/2004/07/SelfHostingServicePaymentLibraray")]
    public partial class CreditCardException : object, System.Runtime.Serialization.IExtensibleDataObject
    {
        
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private string messageField;
        
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string message
        {
            get
            {
                return this.messageField;
            }
            set
            {
                this.messageField = value;
            }
        }
    }
}


[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
[System.ServiceModel.ServiceContractAttribute(ConfigurationName="IPayment")]
public interface IPayment
{
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPayment/ValidateCard", ReplyAction="http://tempuri.org/IPayment/ValidateCardResponse")]
    [System.ServiceModel.FaultContractAttribute(typeof(SelfHostingServicePaymentLibraray.CreditCardException), Action="http://tempuri.org/IPayment/ValidateCardCreditCardExceptionFault", Name="CreditCardException", Namespace="http://schemas.datacontract.org/2004/07/SelfHostingServicePaymentLibraray")]
    bool ValidateCard(SelfHostingServicePaymentLibraray.CreditCard cc);
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPayment/ValidateCard", ReplyAction="http://tempuri.org/IPayment/ValidateCardResponse")]
    System.Threading.Tasks.Task<bool> ValidateCardAsync(SelfHostingServicePaymentLibraray.CreditCard cc);
}

[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
public interface IPaymentChannel : IPayment, System.ServiceModel.IClientChannel
{
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
public partial class PaymentClient : System.ServiceModel.ClientBase<IPayment>, IPayment
{
    
    public PaymentClient()
    {
    }
    
    public PaymentClient(string endpointConfigurationName) : 
            base(endpointConfigurationName)
    {
    }
    
    public PaymentClient(string endpointConfigurationName, string remoteAddress) : 
            base(endpointConfigurationName, remoteAddress)
    {
    }
    
    public PaymentClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
            base(endpointConfigurationName, remoteAddress)
    {
    }
    
    public PaymentClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
            base(binding, remoteAddress)
    {
    }
    
    public bool ValidateCard(SelfHostingServicePaymentLibraray.CreditCard cc)
    {
        return base.Channel.ValidateCard(cc);
    }
    
    public System.Threading.Tasks.Task<bool> ValidateCardAsync(SelfHostingServicePaymentLibraray.CreditCard cc)
    {
        return base.Channel.ValidateCardAsync(cc);
    }
}
