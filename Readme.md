<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128585604/13.2.7%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E5137)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [Customer.cs](./CS/E5137/Customer.cs) (VB: [Customer.vb](./VB/E5137/Customer.vb))
* [EndPointHelper.cs](./CS/E5137/EndPointHelper.cs) (VB: [EndPointHelper.vb](./VB/E5137/EndPointHelper.vb))
* [Program.cs](./CS/E5137/Program.cs) (VB: [Program.vb](./VB/E5137/Program.vb))
* [Service1.svc.cs](./CS/WcfService1/Service1.svc.cs) (VB: [Service1.svc.vb](./VB/WcfService1/Service1.svc.vb))
<!-- default file list end -->
# How to connect to remote data store and configure WCF end point programmatically


<p><strong>Scenario</strong></p>
<p>In this example, we will create a WCF IDataStore service that will be used by our client (Console Application) as a data layer. Instead of a direct connection to the database, our client will connect to a remote service and configure the WCF end point programmatically. This is usually helpful when: <br><strong>-</strong> WCF specific customizations are required to provide custom bindings, endpoints, behavior, e.g. for a secured connection;<br><strong>-</strong> Your WCF service is not hosted in IIS and thus no <a href="http://stackoverflow.com/questions/2113461/">.svc files</a> are used (e.g., when the WCF Class Library project is used).</p>
<p><strong>Steps to implement</strong><br><strong>1. </strong>Create a remote data service and client as described in the <a href="https://www.devexpress.com/Support/Center/p/E4930">How to connect to a remote data service instead of using a direct database connection</a> example.</p>
<p><strong>2. </strong>Create an <em>EndPointHelper </em>class which implements the <em>GetDataStore</em> static method as shown in the <em>EndPointHelper.xx</em> file. This method will be used to configure the WCF end point on the client.<br>The key is in manual creation and custom configuration of the <a href="https://documentation.devexpress.com/#XPO/clsDevExpressXpoDBDataStoreClienttopic">DataStoreClient</a> and <a href="https://documentation.devexpress.com/#XPO/clsDevExpressXpoDBCachedDataStoreClienttopic">CachedDataStoreClient</a> objects (you can see their default configurations by checking the source code of the <em>CreateWCFWebServiceStore</em> and <em>CreateWCFTcpServiceStore</em> methods of the <em>DevExpress.Xpo.XpoDefault</em> class).</p>
<p><strong>3.</strong> Use the <em>GetDataStore </em>static method in the Main method as shown in the <em>Program.xx</em> file to configure end point and create a IDataStore.</p>
<p><strong>Important notes<br></strong><strong>1. </strong>Take special note that binding customizations must be done both in client and service programs.</p>
<p><strong>2. </strong>In XAF applications it is necessary to create a class that implements the <em>IXpoDataStoreProvider</em> interface and return the configured IDataStore. For additional information please refer to the <a href="https://www.devexpress.com/Support/Center/p/e411">How to use a custom ObjectSpaceProvider in XAF</a> example that illustrates implementation of the <em>IXpoDataStoreProvider</em> interface.</p>
<p> </p>
<p><strong>Troubleshooting</strong><br>1. If WCF throws the "<em>Entity is too large</em>" error, you can apply a standard solution from StackOverFlow: <a href="http://stackoverflow.com/questions/10122957/">http://stackoverflow.com/questions/10122957/</a><br>2. If WCF throws the "<em>The maximum string content length quota (8192) has been exceeded while reading XML data.</em>" error, you can extend bindings in the following manner:</p>


```xml
<bindings>
      <basicHttpBinding>
        <binding name="ServicesBinding" maxBufferPoolSize="2147483647" maxReceivedMessageSize="2147483647" maxBufferSize="2147483647" transferMode="Streamed" >
          <readerQuotas maxDepth="2147483647"
            maxArrayLength="2147483647"
            maxStringContentLength="2147483647"/>
        </binding>
      </basicHttpBinding>
</bindings>
```


<p>See <a href="http://stackoverflow.com/questions/6600057/the-maximum-string-content-length-quota-8192-has-been-exceeded-while-reading-x">The maximum string content length quota (8192) has been exceeded while reading XML data</a></p>
<p><strong>See also:<br></strong><a href="http://msdn.microsoft.com/en-us/library/ms733107(v=vs.110).aspx">Endpoints: Addresses, Bindings, and Contracts</a><strong><br></strong><a href="https://www.devexpress.com/Support/Center/p/e4993">How to connect to a remote data service from a Silverlight application</a><strong><br></strong><a href="https://www.devexpress.com/Support/Center/p/e5072">How to implement a distributed object layer service working via WCF</a><br><a href="https://www.devexpress.com/Support/Center/p/e4932">How to create a data caching service that helps improve performance in distributed applications</a><br><a href="https://www.devexpress.com/Support/Center/p/e4930">How to connect to a remote data service instead of using a direct database connection</a><br><a href="https://www.devexpress.com/Support/Center/p/Q413907">Extended IDataStore WCF-Service for tracking user access rights on the server after passing logon credentials from a client app</a><br>The GlobalDataClientChannelCreated or ClientChannelCreated events of the <a href="https://documentation.devexpress.com/CoreLibraries/DevExpressXpoDB.aspx">DevExpress.Xpo.DB</a> > <a href="https://documentation.devexpress.com/CoreLibraries/clsDevExpressXpoDBDataStoreClienttopic.aspx">DataStoreClient</a> class.<br><u></u></p>
<p> </p>

<br/>


