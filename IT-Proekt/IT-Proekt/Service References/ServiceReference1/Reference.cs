﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace IT_Proekt.ServiceReference1 {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.CollectionDataContractAttribute(Name="ArrayOfString", Namespace="http://tempuri.org/", ItemName="string")]
    [System.SerializableAttribute()]
    public class ArrayOfString : System.Collections.Generic.List<string> {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.CollectionDataContractAttribute(Name="ArrayOfInt", Namespace="http://tempuri.org/", ItemName="int")]
    [System.SerializableAttribute()]
    public class ArrayOfInt : System.Collections.Generic.List<int> {
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.WebServiceSoap")]
    public interface WebServiceSoap {
        
        // CODEGEN: Generating message contract since element name HelloWorldResult from namespace http://tempuri.org/ is not marked nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/HelloWorld", ReplyAction="*")]
        IT_Proekt.ServiceReference1.HelloWorldResponse HelloWorld(IT_Proekt.ServiceReference1.HelloWorldRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/HelloWorld", ReplyAction="*")]
        System.Threading.Tasks.Task<IT_Proekt.ServiceReference1.HelloWorldResponse> HelloWorldAsync(IT_Proekt.ServiceReference1.HelloWorldRequest request);
        
        // CODEGEN: Generating message contract since element name getAllUsersResult from namespace http://tempuri.org/ is not marked nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/getAllUsers", ReplyAction="*")]
        IT_Proekt.ServiceReference1.getAllUsersResponse getAllUsers(IT_Proekt.ServiceReference1.getAllUsersRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/getAllUsers", ReplyAction="*")]
        System.Threading.Tasks.Task<IT_Proekt.ServiceReference1.getAllUsersResponse> getAllUsersAsync(IT_Proekt.ServiceReference1.getAllUsersRequest request);
        
        // CODEGEN: Generating message contract since element name getAlbumNamesResult from namespace http://tempuri.org/ is not marked nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/getAlbumNames", ReplyAction="*")]
        IT_Proekt.ServiceReference1.getAlbumNamesResponse getAlbumNames(IT_Proekt.ServiceReference1.getAlbumNamesRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/getAlbumNames", ReplyAction="*")]
        System.Threading.Tasks.Task<IT_Proekt.ServiceReference1.getAlbumNamesResponse> getAlbumNamesAsync(IT_Proekt.ServiceReference1.getAlbumNamesRequest request);
        
        // CODEGEN: Generating message contract since element name name from namespace http://tempuri.org/ is not marked nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/getAlbumYearByName", ReplyAction="*")]
        IT_Proekt.ServiceReference1.getAlbumYearByNameResponse getAlbumYearByName(IT_Proekt.ServiceReference1.getAlbumYearByNameRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/getAlbumYearByName", ReplyAction="*")]
        System.Threading.Tasks.Task<IT_Proekt.ServiceReference1.getAlbumYearByNameResponse> getAlbumYearByNameAsync(IT_Proekt.ServiceReference1.getAlbumYearByNameRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class HelloWorldRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="HelloWorld", Namespace="http://tempuri.org/", Order=0)]
        public IT_Proekt.ServiceReference1.HelloWorldRequestBody Body;
        
        public HelloWorldRequest() {
        }
        
        public HelloWorldRequest(IT_Proekt.ServiceReference1.HelloWorldRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute()]
    public partial class HelloWorldRequestBody {
        
        public HelloWorldRequestBody() {
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class HelloWorldResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="HelloWorldResponse", Namespace="http://tempuri.org/", Order=0)]
        public IT_Proekt.ServiceReference1.HelloWorldResponseBody Body;
        
        public HelloWorldResponse() {
        }
        
        public HelloWorldResponse(IT_Proekt.ServiceReference1.HelloWorldResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class HelloWorldResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string HelloWorldResult;
        
        public HelloWorldResponseBody() {
        }
        
        public HelloWorldResponseBody(string HelloWorldResult) {
            this.HelloWorldResult = HelloWorldResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class getAllUsersRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="getAllUsers", Namespace="http://tempuri.org/", Order=0)]
        public IT_Proekt.ServiceReference1.getAllUsersRequestBody Body;
        
        public getAllUsersRequest() {
        }
        
        public getAllUsersRequest(IT_Proekt.ServiceReference1.getAllUsersRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute()]
    public partial class getAllUsersRequestBody {
        
        public getAllUsersRequestBody() {
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class getAllUsersResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="getAllUsersResponse", Namespace="http://tempuri.org/", Order=0)]
        public IT_Proekt.ServiceReference1.getAllUsersResponseBody Body;
        
        public getAllUsersResponse() {
        }
        
        public getAllUsersResponse(IT_Proekt.ServiceReference1.getAllUsersResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class getAllUsersResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public IT_Proekt.ServiceReference1.ArrayOfString getAllUsersResult;
        
        public getAllUsersResponseBody() {
        }
        
        public getAllUsersResponseBody(IT_Proekt.ServiceReference1.ArrayOfString getAllUsersResult) {
            this.getAllUsersResult = getAllUsersResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class getAlbumNamesRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="getAlbumNames", Namespace="http://tempuri.org/", Order=0)]
        public IT_Proekt.ServiceReference1.getAlbumNamesRequestBody Body;
        
        public getAlbumNamesRequest() {
        }
        
        public getAlbumNamesRequest(IT_Proekt.ServiceReference1.getAlbumNamesRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute()]
    public partial class getAlbumNamesRequestBody {
        
        public getAlbumNamesRequestBody() {
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class getAlbumNamesResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="getAlbumNamesResponse", Namespace="http://tempuri.org/", Order=0)]
        public IT_Proekt.ServiceReference1.getAlbumNamesResponseBody Body;
        
        public getAlbumNamesResponse() {
        }
        
        public getAlbumNamesResponse(IT_Proekt.ServiceReference1.getAlbumNamesResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class getAlbumNamesResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public IT_Proekt.ServiceReference1.ArrayOfString getAlbumNamesResult;
        
        public getAlbumNamesResponseBody() {
        }
        
        public getAlbumNamesResponseBody(IT_Proekt.ServiceReference1.ArrayOfString getAlbumNamesResult) {
            this.getAlbumNamesResult = getAlbumNamesResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class getAlbumYearByNameRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="getAlbumYearByName", Namespace="http://tempuri.org/", Order=0)]
        public IT_Proekt.ServiceReference1.getAlbumYearByNameRequestBody Body;
        
        public getAlbumYearByNameRequest() {
        }
        
        public getAlbumYearByNameRequest(IT_Proekt.ServiceReference1.getAlbumYearByNameRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class getAlbumYearByNameRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string name;
        
        public getAlbumYearByNameRequestBody() {
        }
        
        public getAlbumYearByNameRequestBody(string name) {
            this.name = name;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class getAlbumYearByNameResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="getAlbumYearByNameResponse", Namespace="http://tempuri.org/", Order=0)]
        public IT_Proekt.ServiceReference1.getAlbumYearByNameResponseBody Body;
        
        public getAlbumYearByNameResponse() {
        }
        
        public getAlbumYearByNameResponse(IT_Proekt.ServiceReference1.getAlbumYearByNameResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class getAlbumYearByNameResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public IT_Proekt.ServiceReference1.ArrayOfInt getAlbumYearByNameResult;
        
        public getAlbumYearByNameResponseBody() {
        }
        
        public getAlbumYearByNameResponseBody(IT_Proekt.ServiceReference1.ArrayOfInt getAlbumYearByNameResult) {
            this.getAlbumYearByNameResult = getAlbumYearByNameResult;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface WebServiceSoapChannel : IT_Proekt.ServiceReference1.WebServiceSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class WebServiceSoapClient : System.ServiceModel.ClientBase<IT_Proekt.ServiceReference1.WebServiceSoap>, IT_Proekt.ServiceReference1.WebServiceSoap {
        
        public WebServiceSoapClient() {
        }
        
        public WebServiceSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public WebServiceSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WebServiceSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WebServiceSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        IT_Proekt.ServiceReference1.HelloWorldResponse IT_Proekt.ServiceReference1.WebServiceSoap.HelloWorld(IT_Proekt.ServiceReference1.HelloWorldRequest request) {
            return base.Channel.HelloWorld(request);
        }
        
        public string HelloWorld() {
            IT_Proekt.ServiceReference1.HelloWorldRequest inValue = new IT_Proekt.ServiceReference1.HelloWorldRequest();
            inValue.Body = new IT_Proekt.ServiceReference1.HelloWorldRequestBody();
            IT_Proekt.ServiceReference1.HelloWorldResponse retVal = ((IT_Proekt.ServiceReference1.WebServiceSoap)(this)).HelloWorld(inValue);
            return retVal.Body.HelloWorldResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<IT_Proekt.ServiceReference1.HelloWorldResponse> IT_Proekt.ServiceReference1.WebServiceSoap.HelloWorldAsync(IT_Proekt.ServiceReference1.HelloWorldRequest request) {
            return base.Channel.HelloWorldAsync(request);
        }
        
        public System.Threading.Tasks.Task<IT_Proekt.ServiceReference1.HelloWorldResponse> HelloWorldAsync() {
            IT_Proekt.ServiceReference1.HelloWorldRequest inValue = new IT_Proekt.ServiceReference1.HelloWorldRequest();
            inValue.Body = new IT_Proekt.ServiceReference1.HelloWorldRequestBody();
            return ((IT_Proekt.ServiceReference1.WebServiceSoap)(this)).HelloWorldAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        IT_Proekt.ServiceReference1.getAllUsersResponse IT_Proekt.ServiceReference1.WebServiceSoap.getAllUsers(IT_Proekt.ServiceReference1.getAllUsersRequest request) {
            return base.Channel.getAllUsers(request);
        }
        
        public IT_Proekt.ServiceReference1.ArrayOfString getAllUsers() {
            IT_Proekt.ServiceReference1.getAllUsersRequest inValue = new IT_Proekt.ServiceReference1.getAllUsersRequest();
            inValue.Body = new IT_Proekt.ServiceReference1.getAllUsersRequestBody();
            IT_Proekt.ServiceReference1.getAllUsersResponse retVal = ((IT_Proekt.ServiceReference1.WebServiceSoap)(this)).getAllUsers(inValue);
            return retVal.Body.getAllUsersResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<IT_Proekt.ServiceReference1.getAllUsersResponse> IT_Proekt.ServiceReference1.WebServiceSoap.getAllUsersAsync(IT_Proekt.ServiceReference1.getAllUsersRequest request) {
            return base.Channel.getAllUsersAsync(request);
        }
        
        public System.Threading.Tasks.Task<IT_Proekt.ServiceReference1.getAllUsersResponse> getAllUsersAsync() {
            IT_Proekt.ServiceReference1.getAllUsersRequest inValue = new IT_Proekt.ServiceReference1.getAllUsersRequest();
            inValue.Body = new IT_Proekt.ServiceReference1.getAllUsersRequestBody();
            return ((IT_Proekt.ServiceReference1.WebServiceSoap)(this)).getAllUsersAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        IT_Proekt.ServiceReference1.getAlbumNamesResponse IT_Proekt.ServiceReference1.WebServiceSoap.getAlbumNames(IT_Proekt.ServiceReference1.getAlbumNamesRequest request) {
            return base.Channel.getAlbumNames(request);
        }
        
        public IT_Proekt.ServiceReference1.ArrayOfString getAlbumNames() {
            IT_Proekt.ServiceReference1.getAlbumNamesRequest inValue = new IT_Proekt.ServiceReference1.getAlbumNamesRequest();
            inValue.Body = new IT_Proekt.ServiceReference1.getAlbumNamesRequestBody();
            IT_Proekt.ServiceReference1.getAlbumNamesResponse retVal = ((IT_Proekt.ServiceReference1.WebServiceSoap)(this)).getAlbumNames(inValue);
            return retVal.Body.getAlbumNamesResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<IT_Proekt.ServiceReference1.getAlbumNamesResponse> IT_Proekt.ServiceReference1.WebServiceSoap.getAlbumNamesAsync(IT_Proekt.ServiceReference1.getAlbumNamesRequest request) {
            return base.Channel.getAlbumNamesAsync(request);
        }
        
        public System.Threading.Tasks.Task<IT_Proekt.ServiceReference1.getAlbumNamesResponse> getAlbumNamesAsync() {
            IT_Proekt.ServiceReference1.getAlbumNamesRequest inValue = new IT_Proekt.ServiceReference1.getAlbumNamesRequest();
            inValue.Body = new IT_Proekt.ServiceReference1.getAlbumNamesRequestBody();
            return ((IT_Proekt.ServiceReference1.WebServiceSoap)(this)).getAlbumNamesAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        IT_Proekt.ServiceReference1.getAlbumYearByNameResponse IT_Proekt.ServiceReference1.WebServiceSoap.getAlbumYearByName(IT_Proekt.ServiceReference1.getAlbumYearByNameRequest request) {
            return base.Channel.getAlbumYearByName(request);
        }
        
        public IT_Proekt.ServiceReference1.ArrayOfInt getAlbumYearByName(string name) {
            IT_Proekt.ServiceReference1.getAlbumYearByNameRequest inValue = new IT_Proekt.ServiceReference1.getAlbumYearByNameRequest();
            inValue.Body = new IT_Proekt.ServiceReference1.getAlbumYearByNameRequestBody();
            inValue.Body.name = name;
            IT_Proekt.ServiceReference1.getAlbumYearByNameResponse retVal = ((IT_Proekt.ServiceReference1.WebServiceSoap)(this)).getAlbumYearByName(inValue);
            return retVal.Body.getAlbumYearByNameResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<IT_Proekt.ServiceReference1.getAlbumYearByNameResponse> IT_Proekt.ServiceReference1.WebServiceSoap.getAlbumYearByNameAsync(IT_Proekt.ServiceReference1.getAlbumYearByNameRequest request) {
            return base.Channel.getAlbumYearByNameAsync(request);
        }
        
        public System.Threading.Tasks.Task<IT_Proekt.ServiceReference1.getAlbumYearByNameResponse> getAlbumYearByNameAsync(string name) {
            IT_Proekt.ServiceReference1.getAlbumYearByNameRequest inValue = new IT_Proekt.ServiceReference1.getAlbumYearByNameRequest();
            inValue.Body = new IT_Proekt.ServiceReference1.getAlbumYearByNameRequestBody();
            inValue.Body.name = name;
            return ((IT_Proekt.ServiceReference1.WebServiceSoap)(this)).getAlbumYearByNameAsync(inValue);
        }
    }
}
