<%@ Page Language="C#" Inherits="System.Web.UI.Page"%>
<%@ Assembly Name="Microsoft.SharePoint, Version=12.0.0.0,Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Import Namespace="Microsoft.SharePoint.Utilities" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<% Response.ContentType = "text/xml"; %>
<wsdl:definitions xmlns:soap="http://schemas.xmlsoap.org/wsdl/soap/" xmlns:tm="http://microsoft.com/wsdl/mime/textMatching/" xmlns:soapenc="http://schemas.xmlsoap.org/soap/encoding/" xmlns:mime="http://schemas.xmlsoap.org/wsdl/mime/" xmlns:tns="http://integrations.at/favorites" xmlns:s="http://www.w3.org/2001/XMLSchema" xmlns:soap12="http://schemas.xmlsoap.org/wsdl/soap12/" xmlns:http="http://schemas.xmlsoap.org/wsdl/http/" targetNamespace="http://integrations.at/favorites" xmlns:wsdl="http://schemas.xmlsoap.org/wsdl/">
  <wsdl:types>
    <s:schema elementFormDefault="qualified" targetNamespace="http://integrations.at/favorites">
      <s:element name="GetSites">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="siteCollection" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="GetSitesResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="GetSitesResult" type="tns:ArrayOfString" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:complexType name="ArrayOfString">
        <s:sequence>
          <s:element minOccurs="0" maxOccurs="unbounded" name="string" nillable="true" type="s:string" />
        </s:sequence>
      </s:complexType>
      <s:element name="GetFavoritesListsForWeb">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="SiteCollection" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="Web" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="GetFavoritesListsForWebResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="GetFavoritesListsForWebResult" type="tns:ArrayOfString" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="UploadFavorites">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="SiteCollection" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="SharepointSite" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="List" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="Favorites" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="UploadFavoritesResponse">
        <s:complexType />
      </s:element>
      <s:element name="GetRemoteFavorites">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="SiteCollection" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="SharepointSite" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="List" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="GetRemoteFavoritesResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="GetRemoteFavoritesResult" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
    </s:schema>
  </wsdl:types>
  <wsdl:message name="GetSitesSoapIn">
    <wsdl:part name="parameters" element="tns:GetSites" />
  </wsdl:message>
  <wsdl:message name="GetSitesSoapOut">
    <wsdl:part name="parameters" element="tns:GetSitesResponse" />
  </wsdl:message>
  <wsdl:message name="GetFavoritesListsForWebSoapIn">
    <wsdl:part name="parameters" element="tns:GetFavoritesListsForWeb" />
  </wsdl:message>
  <wsdl:message name="GetFavoritesListsForWebSoapOut">
    <wsdl:part name="parameters" element="tns:GetFavoritesListsForWebResponse" />
  </wsdl:message>
  <wsdl:message name="UploadFavoritesSoapIn">
    <wsdl:part name="parameters" element="tns:UploadFavorites" />
  </wsdl:message>
  <wsdl:message name="UploadFavoritesSoapOut">
    <wsdl:part name="parameters" element="tns:UploadFavoritesResponse" />
  </wsdl:message>
  <wsdl:message name="GetRemoteFavoritesSoapIn">
    <wsdl:part name="parameters" element="tns:GetRemoteFavorites" />
  </wsdl:message>
  <wsdl:message name="GetRemoteFavoritesSoapOut">
    <wsdl:part name="parameters" element="tns:GetRemoteFavoritesResponse" />
  </wsdl:message>
  <wsdl:portType name="FavoritesWSSoap">
    <wsdl:operation name="GetSites">
      <wsdl:input message="tns:GetSitesSoapIn" />
      <wsdl:output message="tns:GetSitesSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="GetFavoritesListsForWeb">
      <wsdl:input message="tns:GetFavoritesListsForWebSoapIn" />
      <wsdl:output message="tns:GetFavoritesListsForWebSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="UploadFavorites">
      <wsdl:input message="tns:UploadFavoritesSoapIn" />
      <wsdl:output message="tns:UploadFavoritesSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="GetRemoteFavorites">
      <wsdl:input message="tns:GetRemoteFavoritesSoapIn" />
      <wsdl:output message="tns:GetRemoteFavoritesSoapOut" />
    </wsdl:operation>
  </wsdl:portType>
  <wsdl:binding name="FavoritesWSSoap" type="tns:FavoritesWSSoap">
    <soap:binding transport="http://schemas.xmlsoap.org/soap/http" />
    <wsdl:operation name="GetSites">
      <soap:operation soapAction="http://integrations.at/favorites/GetSites" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="GetFavoritesListsForWeb">
      <soap:operation soapAction="http://integrations.at/favorites/GetFavoritesListsForWeb" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="UploadFavorites">
      <soap:operation soapAction="http://integrations.at/favorites/UploadFavorites" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="GetRemoteFavorites">
      <soap:operation soapAction="http://integrations.at/favorites/GetRemoteFavorites" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
  </wsdl:binding>
  <wsdl:binding name="FavoritesWSSoap12" type="tns:FavoritesWSSoap">
    <soap12:binding transport="http://schemas.xmlsoap.org/soap/http" />
    <wsdl:operation name="GetSites">
      <soap12:operation soapAction="http://integrations.at/favorites/GetSites" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="GetFavoritesListsForWeb">
      <soap12:operation soapAction="http://integrations.at/favorites/GetFavoritesListsForWeb" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="UploadFavorites">
      <soap12:operation soapAction="http://integrations.at/favorites/UploadFavorites" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="GetRemoteFavorites">
      <soap12:operation soapAction="http://integrations.at/favorites/GetRemoteFavorites" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
  </wsdl:binding>
  <wsdl:service name="FavoritesWS">
    <wsdl:port name="FavoritesWSSoap" binding="tns:FavoritesWSSoap">
     <soap:address location=<% SPHttpUtility.AddQuote(SPHttpUtility.HtmlEncode(SPWeb.OriginalBaseUrl(Request)),Response.Output); %> />
              </wsdl:port>
    <wsdl:port name="FavoritesWSSoap12" binding="tns:FavoritesWSSoap12">
     <soap:address location=<% SPHttpUtility.AddQuote(SPHttpUtility.HtmlEncode(SPWeb.OriginalBaseUrl(Request)),Response.Output); %> />
          </wsdl:port>
  </wsdl:service>
</wsdl:definitions>