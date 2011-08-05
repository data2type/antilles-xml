<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
	xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:xd="http://www.oxygenxml.com/ns/doc/xsl"
	xmlns:d2t="http://www.data2type.de/word" exclude-result-prefixes="xs xd d2t" version="2.0">
	<xd:doc scope="stylesheet">
		<xd:desc>
			<xd:p><xd:b>Created on:</xd:b> Jan 13, 2011</xd:p>
			<xd:p><xd:b>Author:</xd:b> d2t</xd:p>
			<xd:p></xd:p>
		</xd:desc>
	</xd:doc>
	<xsl:template match="section/p[1]">
		<heading>
			<xsl:copy-of select="@*"/>
			<xsl:apply-templates/>
		</heading>
	</xsl:template>
	<xsl:template match="inline[@type='d2t:link'][count(*)=1][every $node 
		in node() 
		satisfies (normalize-space($node)='' or $node/self::inline)]">
		<xsl:copy>
			<xsl:apply-templates select="inline/@*"/>
			<xsl:apply-templates select="@*"/>
			<xsl:apply-templates select="inline/node()"/>
		</xsl:copy>
	</xsl:template>
	<!-- 
		kopiert alle Knoten:
	-->
	<xsl:template match="node() | @*">
		<xsl:copy>
			<xsl:apply-templates select="node() | @*"/>
		</xsl:copy>
	</xsl:template>
</xsl:stylesheet>