<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet xmlns:d2t="http://www.data2type.de/word" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:xd="http://www.oxygenxml.com/ns/doc/xsl"
    xmlns:saxon="http://saxon.sf.net/" xmlns="" exclude-result-prefixes="xs xd d2t saxon" version="2.0">
    <xd:doc scope="stylesheet">
        <xd:desc>
            <xd:p><xd:b>Created on:</xd:b> Nov 5, 2010</xd:p>
            <xd:p><xd:b>Author:</xd:b> d2t</xd:p>
            <xd:p/>
        </xd:desc>
    </xd:doc>
    <xsl:output method="xml"/>
    <!-- 
    allgemeine Variablen:
-->
    <xsl:variable name="config" select="//d2t:config/*"/>
    <xsl:variable name="maxLevel"
        select="max($config//tr[number(td[@class='level'])>0]/td[@class='level'])"/>
    <xsl:variable name="groupingElement"
        select="$config//tr[td[@id='d2t:container']]/td[@class='targetElement']"/>
    <xsl:variable name="groupMap">
        <xsl:for-each select="$config//tr[number(td[@class='level'])>0]">
            <xsl:sort select="td[@class='level']" order="ascending"/>
            <d2t:map>
                <d2t:level>
                    <xsl:value-of select="td[@class='level']"/>
                </d2t:level>
                <d2t:element>
                    <xsl:value-of select="td[@class='targetElement']"/>
                </d2t:element>
            </d2t:map>
        </xsl:for-each>
    </xsl:variable>
    <!-- 
        erster Gruppierungsaufruf
    -->
    <xsl:template match="d2t:content/*">
        <xsl:variable name="doc" select="."/>
        <xsl:copy>
            <xsl:call-template name="grouping">
                <xsl:with-param name="level">1</xsl:with-param>
            </xsl:call-template>
        </xsl:copy>
    </xsl:template>
    <!-- 
        Gruppierungs-Template
        gruppiert $group in Gruppen, die mit entsprechendem Element beginnen
        Indikator-Element ist abhängig von der Ebene ($level)
    -->
    <xsl:template name="grouping">
        <xsl:param name="level"/>
        <xsl:param name="group" select="node()"/>
        <xsl:variable name="label" select="$groupMap/d2t:map[d2t:level=$level]/d2t:element"/>
        <xsl:for-each-group select="$group" group-starting-with="*[name()=$label]">
            <xsl:choose>
                <xsl:when test="current-group()[1]/self::*[name()=$label]">
                    <xsl:element name="{$groupingElement}">
                        <xsl:choose>
                            <xsl:when test="$level=$maxLevel">
                                <xsl:apply-templates select="current-group()"/>
                            </xsl:when>
                            <xsl:otherwise>
                                <!-- Aufruf der aktuellen Gruppe für die nächsten Grupierungsebene (level um eins erhöht): -->
                                <xsl:call-template name="grouping">
                                    <xsl:with-param name="level" select="$level+1"/>
                                    <xsl:with-param name="group" select="current-group()"/>
                                </xsl:call-template>
                            </xsl:otherwise>
                        </xsl:choose>
                    </xsl:element>
                </xsl:when>
                <xsl:otherwise>
                    <xsl:apply-templates select="current-group()"/>
                </xsl:otherwise>
            </xsl:choose>
        </xsl:for-each-group>
    </xsl:template>
    <!-- 
    Entfernt den Überbau:
-->
    <xsl:template match="d2t:config"/>
    <xsl:template match="d2t:content|d2t:root">
        <xsl:apply-templates/>
    </xsl:template>
    <xsl:template match="@class|@type"/>
    <!-- 
        kopiert alle Elemente, Attribute und übrige Knoten:
    -->
    <xsl:template match="node() | @*">
        <xsl:copy>
            <xsl:apply-templates select="node() | @*"/>
        </xsl:copy>
    </xsl:template>
</xsl:stylesheet>
