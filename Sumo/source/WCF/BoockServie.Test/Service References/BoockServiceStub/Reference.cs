﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BoockServie.Test.BoockServiceStub {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="BoockServiceStub.IDbMetaManager")]
    public interface IDbMetaManager {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDbMetaManager/CreateQuery", ReplyAction="http://tempuri.org/IDbMetaManager/CreateQueryResponse")]
        Sumo.Api.SumoSession CreateQuery(string query);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDbMetaManager/CreateQuery", ReplyAction="http://tempuri.org/IDbMetaManager/CreateQueryResponse")]
        System.Threading.Tasks.Task<Sumo.Api.SumoSession> CreateQueryAsync(string query);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDbMetaManager/GetDocuments", ReplyAction="http://tempuri.org/IDbMetaManager/GetDocumentsResponse")]
        System.Collections.Generic.List<Sumo.Api.Book> GetDocuments(int sessionId, int count, int offset);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDbMetaManager/GetDocuments", ReplyAction="http://tempuri.org/IDbMetaManager/GetDocumentsResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<Sumo.Api.Book>> GetDocumentsAsync(int sessionId, int count, int offset);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDbMetaManager/GetStatistic", ReplyAction="http://tempuri.org/IDbMetaManager/GetStatisticResponse")]
        Sumo.Api.CategoriesMultiList GetStatistic(int sessionId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDbMetaManager/GetStatistic", ReplyAction="http://tempuri.org/IDbMetaManager/GetStatisticResponse")]
        System.Threading.Tasks.Task<Sumo.Api.CategoriesMultiList> GetStatisticAsync(int sessionId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDbMetaManager/CloseSession", ReplyAction="http://tempuri.org/IDbMetaManager/CloseSessionResponse")]
        void CloseSession(Sumo.Api.SumoSession session);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDbMetaManager/CloseSession", ReplyAction="http://tempuri.org/IDbMetaManager/CloseSessionResponse")]
        System.Threading.Tasks.Task CloseSessionAsync(Sumo.Api.SumoSession session);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IDbMetaManagerChannel : BoockServie.Test.BoockServiceStub.IDbMetaManager, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class DbMetaManagerClient : System.ServiceModel.ClientBase<BoockServie.Test.BoockServiceStub.IDbMetaManager>, BoockServie.Test.BoockServiceStub.IDbMetaManager {
        
        public DbMetaManagerClient() {
        }
        
        public DbMetaManagerClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public DbMetaManagerClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DbMetaManagerClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DbMetaManagerClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public Sumo.Api.SumoSession CreateQuery(string query) {
            return base.Channel.CreateQuery(query);
        }
        
        public System.Threading.Tasks.Task<Sumo.Api.SumoSession> CreateQueryAsync(string query) {
            return base.Channel.CreateQueryAsync(query);
        }
        
        public System.Collections.Generic.List<Sumo.Api.Book> GetDocuments(int sessionId, int count, int offset) {
            return base.Channel.GetDocuments(sessionId, count, offset);
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<Sumo.Api.Book>> GetDocumentsAsync(int sessionId, int count, int offset) {
            return base.Channel.GetDocumentsAsync(sessionId, count, offset);
        }
        
        public Sumo.Api.CategoriesMultiList GetStatistic(int sessionId) {
            return base.Channel.GetStatistic(sessionId);
        }
        
        public System.Threading.Tasks.Task<Sumo.Api.CategoriesMultiList> GetStatisticAsync(int sessionId) {
            return base.Channel.GetStatisticAsync(sessionId);
        }
        
        public void CloseSession(Sumo.Api.SumoSession session) {
            base.Channel.CloseSession(session);
        }
        
        public System.Threading.Tasks.Task CloseSessionAsync(Sumo.Api.SumoSession session) {
            return base.Channel.CloseSessionAsync(session);
        }
    }
}