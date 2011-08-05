<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet xmlns:d2t="http://www.data2type.de/word"
    xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:xs="http://www.w3.org/2001/XMLSchema"
    xmlns:xd="http://www.oxygenxml.com/ns/doc/xsl" xmlns:saxon="http://saxon.sf.net/"
    exclude-result-prefixes="xs xd d2t saxon" version="2.0">
    <xd:doc scope="stylesheet">
        <xd:desc>
            <xd:p><xd:b>Created on:</xd:b> Nov 8, 2010</xd:p>
            <xd:p><xd:b>Author:</xd:b> d2t</xd:p>
            <xd:p/>
        </xd:desc>
    </xd:doc>
    <xsl:output method="xml"/>
    <!--  saxon:next-in-chain="converter3.xsl"
    allgemeine Variablen
-->
    <xsl:variable name="config" select="//d2t:config/*"/>
    <xsl:variable name="maxLevel" select="max(//p/@level)"/>
    <!-- Elementname für einen Listenpunkt: -->
    <xsl:variable name="listElement"
        select="$config//tr[td[@id='d2t:listPoint']]/td[@class='targetElement']"/>
    <!-- Elementname für das Container-Element ungeordneter Listen: -->
    <xsl:variable name="ulistContainerElement"
        select="$config//tr[td[@id='d2t:ulistContainer']]/td[@class='targetElement']"/>
    <!-- Elementname für das Container-Element geordneter Listen: -->
    <xsl:variable name="olistContainerElement"
        select="$config//tr[td[@id='d2t:olistContainer']]/td[@class='targetElement']"/>
    <!-- 
    erster Gruppierungsaufruf
-->
    <xsl:template match="d2t:content/*">
        <xsl:copy>
            <xsl:for-each-group select="./*" group-adjacent="exists(@level)">
                <xsl:choose>
                    <xsl:when test="current-grouping-key()">
                        <xsl:call-template name="grouping">
                            <xsl:with-param name="level">1</xsl:with-param>
                            <xsl:with-param name="group" select="current-group()"/>
                        </xsl:call-template>
                    </xsl:when>
                    <xsl:otherwise>
                        <xsl:apply-templates select="current-group()"/>
                    </xsl:otherwise>
                </xsl:choose>
            </xsl:for-each-group>
        </xsl:copy>
    </xsl:template>
    <!-- 
        Gruppierungs-Template
        gruppiert $group in Listen- und Nicht-Listen-Absätze
        
-->
    <xsl:template name="grouping">
        <xsl:param name="level"/>
        <xsl:param name="group" select="*"/>
        <xsl:variable name="listContainerElement"
            select="if (current-group()/@class='d2t:ulist') 
                        then ($ulistContainerElement) 
                        else ($olistContainerElement)"/>
        <xsl:element name="{$listContainerElement}">
            <xsl:for-each-group select="$group" group-adjacent="@level = $level">
                <xsl:choose>
                    <xsl:when test="@level &gt; $level">
                        <xsl:element name="{$listElement}">
                            <xsl:call-template name="grouping">
                                <xsl:with-param name="level" select="$level+1"/>
                                <xsl:with-param name="group" select="current-group()"/>
                            </xsl:call-template>
                        </xsl:element>
                    </xsl:when>
                    <xsl:otherwise>
                        <xsl:apply-templates select="current-group()"/>
                    </xsl:otherwise>
                </xsl:choose>
            </xsl:for-each-group>
        </xsl:element>
    </xsl:template>
    <!-- 
        Wandelt jeden Listenpunkt-Absatz in ein d2t:li-Element um:
    -->
    <xsl:template match="*[local-name()='p'][@class='d2t:ulist' or @class='d2t:olist']">
        <xsl:element name="{$listElement}">
            <xsl:apply-templates/>
        </xsl:element>
    </xsl:template>
    <!-- 
        kopiert alle Elemente, Attribute und übrigen Knoten:
    -->
    <xsl:template match="node() | @*">
        <xsl:copy>
            <xsl:apply-templates select="node() | @*"/>
        </xsl:copy>
    </xsl:template>
</xsl:stylesheet>
