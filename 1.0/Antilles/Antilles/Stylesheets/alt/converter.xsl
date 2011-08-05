<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet xmlns:d2t="http://www.data2type.de/word"
    xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:xhtml="http://www.w3.org/1999/xhtml"
    xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:xd="http://www.oxygenxml.com/ns/doc/xsl"
    xmlns:saxon="http://saxon.sf.net/" exclude-result-prefixes="xs xd d2t saxon" version="2.0">
    <xd:doc scope="stylesheet">
        <xd:desc>
            <xd:p><xd:b>Created on:</xd:b> Nov 4, 2010</xd:p>
            <xd:p><xd:b>Author:</xd:b> d2t</xd:p>
            <xd:p/>
        </xd:desc>
    </xd:doc>
    <xsl:param name="config" required="yes"/>
    <xsl:output method="xml"/>
    <xsl:variable name="configDoc" select="doc($config)"/>
    <xsl:variable name="ids" select="$configDoc//td[@class='formatName']/@id"/>
    <xsl:variable name="clears"
        select="$configDoc//tr[td[@class='option']='clear']/td[@class='formatName']/@id"/>
    <xsl:variable name="deletes"
        select="$configDoc//tr[td[@class='option']='delete']/td[@class='formatName']/@id"/>
    <!--  saxon:next-in-chain="converter2.xsl"
    Erzeugt entsprechendes Root-Element 
    -->
    <xsl:variable name="resolvedConfig">
        <xsl:apply-templates select="$configDoc" mode="config"/>
    </xsl:variable>
    <xsl:template match="tbody//td[@class='targetElement']" mode="config">
        <xsl:copy>
            <xsl:copy-of select="@*"/>
            <xsl:choose>
                <xsl:when test="matches(following-sibling::td[@class='option'],'delete|clear')">
                    <xsl:value-of select="."/>
                </xsl:when>
                <xsl:otherwise>
                    <xsl:variable name="id" select="preceding-sibling::td/@id"/>
                    <xsl:value-of select="QName('',normalize-space($configDoc//tr[td[@id=$id]]/td[@class='targetElement']))"/>
                    <!--<xsl:call-template name="nameFactory">
                        <xsl:with-param name="id" select="preceding-sibling::td/@id"/>
                    </xsl:call-template>-->
                </xsl:otherwise>
            </xsl:choose>
        </xsl:copy>
    </xsl:template>
    <xsl:template match="/">
        <d2t:root>
            <d2t:config>
                <xsl:copy-of select="$resolvedConfig"/>
            </d2t:config>
            <xsl:variable name="root"
                    select="$resolvedConfig//tr[td[@id='d2t:root']]/td[@class='targetElement']"/>
            <d2t:content>
                <xsl:element name="{$root}">
                    <xsl:apply-templates select="xhtml:html/xhtml:body/node()"/>
                </xsl:element>
            </d2t:content>
        </d2t:root>
    </xsl:template>
    <!-- 
    entfernt alle zu löschenden Element-Tags
-->
    <xsl:template match="*[@class=$clears]" priority="10">
        <xsl:apply-templates/>
    </xsl:template>
    <!-- 
    entfernt alle zu löschenden Elemente
-->
    <xsl:template match="*[@class=$deletes]" priority="10"/>
    <!-- 
    wandelt Elemente anhand der Klasse in entsprechendes Element des Mappings um:
-->
    <xsl:template match="*[@class=$ids]">
        <xsl:variable name="class" select="@class"/>
        <xsl:variable name="elementName"
            select="$resolvedConfig//tr[td[@id=$class]]/td[@class='targetElement']"/>
        <xsl:element name="{$elementName}">
            <xsl:apply-templates select="@*"/>
            <xsl:apply-templates/>
        </xsl:element>
    </xsl:template>
    <!--
    wandelt das @rowspan-Attribut um:
-->
    <xsl:template match="@*[name()='rowspan']">
        <xsl:variable name="attributName"
            select="$resolvedConfig//tr[td[@id='d2t:rowspan']]/td[@class='targetElement']"/>
        <xsl:attribute name="{$attributName}" select="."/>
    </xsl:template>
    <!--
        wandelt das @colspan-Attribut um:
    -->
    <xsl:template match="@*[name()='colspan']">
        <xsl:variable name="attributName"
            select="$resolvedConfig//tr[td[@id='d2t:colspan']]/td[@class='targetElement']"/> 
        <xsl:attribute name="{$attributName}" select="."/>
    </xsl:template>
    <!--<xsl:template name="nameFactory">
        <xsl:param name="id"/>
        <xsl:variable name="fromMap" select="$configDoc//tr[td[@id=$id]]/td[@class='targetElement']"/>
        <xsl:choose>
            <xsl:when test="$fromMap castable as xs:NCName">
                <xsl:value-of select="QName('',normalize-space($fromMap))"/>
            </xsl:when>
            <xsl:otherwise>
                <xsl:value-of select="$id"/>
                <xsl:message><xsl:value-of select="$fromMap"
                        /> kann nicht in ein qualified Name umgewandelt werden. Es wurde kein Elementname für das Element/Attribut aus der Zeile <xsl:value-of
                            select="$configDoc//tr/td[@id=$id]"/> festgelegt!</xsl:message>
            </xsl:otherwise>
        </xsl:choose>
    </xsl:template>-->
    <!-- 
    kopiert alle Elemente:
-->
    <xsl:template match="*" priority="-5" mode="#all">
        <xsl:element name="{name()}">
            <xsl:apply-templates select="node() | @*" mode="#current"/>
        </xsl:element>
    </xsl:template>
    <!-- 
    kopiert alle Attribute und übrigen Knoten:
-->
    <xsl:template match="node() | @*" priority="-10" mode="#all">
        <xsl:copy/>
    </xsl:template>
</xsl:stylesheet>
