<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:d2t="http://www.data2type.de/word"
    xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:xd="http://www.oxygenxml.com/ns/doc/xsl"
    xmlns:saxon="http://saxon.sf.net/" exclude-result-prefixes="xs xd saxon" version="2.0">
    <xd:doc scope="stylesheet">
        <xd:desc>
            <xd:p><xd:b>Created on:</xd:b> Nov 4, 2010</xd:p>
            <xd:p><xd:b>Author:</xd:b> d2t</xd:p>
            <xd:p/>
        </xd:desc>
    </xd:doc>
	<xsl:output method="xml" version="1.0" encoding="UTF-8" indent="no"/>
    <xsl:strip-space elements="*"/>
<!--     saxon:next-in-chain="vorprozess6.xsl"
    Wandelt inline-Elemente in entsprechende inzeilige Elemente um
-->
    <xsl:template match="inline[@bold='true']">
        <inline type="inline" style="d2t:b">
            <xsl:apply-templates/>
        </inline>
    </xsl:template>
    <xsl:template match="inline[@italic='true']">
        <inline type="inline" style="d2t:i">
            <xsl:apply-templates/>
        </inline>
    </xsl:template>
    <xsl:template match="inline[@underline='true']">
        <inline type="inline" style="d2t:u">
            <xsl:apply-templates/>
        </inline>
    </xsl:template>
<!--
    entfernt alle inline-Elemente ohne Auszeichnung
-->
    <xsl:template match="inline[not(@*[not(name()='type')])]">
        <xsl:apply-templates/>
    </xsl:template>
    <xsl:template match="node() | @*">
        <xsl:copy>
            <xsl:apply-templates select="node() | @*"/>
        </xsl:copy>
    </xsl:template>
</xsl:stylesheet>
