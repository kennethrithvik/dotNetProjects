﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18408
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BLLayerCreditCard.CreditCardServiceReference {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="CreditCardServiceReference.ICreditCardService")]
    public interface ICreditCardService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICreditCardService/ValidateCard", ReplyAction="http://tempuri.org/ICreditCardService/ValidateCardResponse")]
        bool ValidateCard(string CardNo, System.DateTime ExpDate);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICreditCardService/ValidateCard", ReplyAction="http://tempuri.org/ICreditCardService/ValidateCardResponse")]
        System.Threading.Tasks.Task<bool> ValidateCardAsync(string CardNo, System.DateTime ExpDate);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ICreditCardServiceChannel : BLLayerCreditCard.CreditCardServiceReference.ICreditCardService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class CreditCardServiceClient : System.ServiceModel.ClientBase<BLLayerCreditCard.CreditCardServiceReference.ICreditCardService>, BLLayerCreditCard.CreditCardServiceReference.ICreditCardService {
        
        public CreditCardServiceClient() {
        }
        
        public CreditCardServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public CreditCardServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CreditCardServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CreditCardServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public bool ValidateCard(string CardNo, System.DateTime ExpDate) {
            return base.Channel.ValidateCard(CardNo, ExpDate);
        }
        
        public System.Threading.Tasks.Task<bool> ValidateCardAsync(string CardNo, System.DateTime ExpDate) {
            return base.Channel.ValidateCardAsync(CardNo, ExpDate);
        }
    }
}
