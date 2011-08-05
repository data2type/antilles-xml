<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:d2t="http://www.data2type.de/word"
    xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:xd="http://www.oxygenxml.com/ns/doc/xsl"
    xmlns:saxon="http://saxon.sf.net/" exclude-result-prefixes="xs xd saxon"
    version="2.0">
    <xd:doc scope="stylesheet">
        <xd:desc>
            <xd:p><xd:b>Created on:</xd:b> Nov 4, 2010</xd:p>
            <xd:p><xd:b>Author:</xd:b> d2t</xd:p>
            <xd:p/>
        </xd:desc>
    </xd:doc>
	<xsl:output method="xml" version="1.0" encoding="UTF-8" indent="no"/>
    <xsl:strip-space elements="*"/>
<!--   saxon:next-in-chain="vorprozess5.xsl"
    
    Gruppiert alle aufeinanderfolgenden fett ausgezeichneten inzeiligen Textabschnitte
-->
    <xsl:template match="p">
        <xsl:copy>
        	<xsl:apply-templates select="@*"/>
            <xsl:for-each-group select="inline" group-adjacent="string(@bold)">
                <xsl:choose>
                    <xsl:when test="current-grouping-key()=''">
                        <xsl:call-template name="italic"/>
                    </xsl:when>
                    <xsl:otherwise>
                        <inline bold="true">
                            <xsl:call-template name="italic"/>
                        </inline>
                    </xsl:otherwise>
                </xsl:choose>
            </xsl:for-each-group>
        </xsl:copy>
    </xsl:template>
    <!--  
        
        Gruppiert alle aufeinanderfolgenden kursiv ausgezeichneten inzeiligen Textabschnitte
    -->
    <xsl:template name="italic">
        <xsl:for-each-group select="current-group()" group-adjacent="string(@italic)">
            <xsl:choose>
                <xsl:when test="current-grouping-key()=''">
                    <xsl:apply-templates select="current-group()"/>
                </xsl:when>
                <xsl:otherwise>
                    <inline italic="true">
                        <xsl:apply-templates select="current-group()"/>
                    </inline>
                </xsl:otherwise>
            </xsl:choose>
        </xsl:for-each-group>
    </xsl:template>
    <xsl:template match="@bold"/>
    <xsl:template match="@italic"/>
    <!--
        
        Kopiert alle Knoten und Attribute
    -->
    <xsl:template match="node() | @*">
        <xsl:copy>
            <xsl:apply-templates select="node() | @*"/>
        </xsl:copy>
    </xsl:template>
</xsl:stylesheet>
