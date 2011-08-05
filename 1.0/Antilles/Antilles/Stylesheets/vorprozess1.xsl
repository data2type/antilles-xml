<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
	xmlns:xd="http://www.oxygenxml.com/ns/doc/xsl"
	xmlns:aml="http://schemas.microsoft.com/aml/2001/core"
	xmlns:dt="uuid:C2F41010-65B3-11d1-A29F-00AA00C14882"
	xmlns:ve="http://schemas.openxmlformats.org/markup-compatibility/2006"
	xmlns:o="urn:schemas-microsoft-com:office:office" xmlns:v="urn:schemas-microsoft-com:vml"
	xmlns:w10="urn:schemas-microsoft-com:office:word"
	xmlns:w="http://schemas.microsoft.com/office/word/2003/wordml"
	xmlns:wx="http://schemas.microsoft.com/office/word/2003/auxHint"
	xmlns:wsp="http://schemas.microsoft.com/office/word/2003/wordml/sp2"
	xmlns:sl="http://schemas.microsoft.com/schemaLibrary/2003/core"
	xmlns="http://www.w3.org/1999/xhtml"
	extension-element-prefixes="wx saxon w w10 wsp sl aml dt ve o v"
	xmlns:saxon="http://saxon.sf.net/" version="2.0">
	<xd:doc scope="stylesheet">
		<xd:desc>
			<xd:p><xd:b>Created on:</xd:b> Nov 10, 2010</xd:p>
			<xd:p><xd:b>Author:</xd:b> d2t</xd:p>
			<xd:p/>
		</xd:desc>
	</xd:doc>
	<xsl:output method="xml" version="1.0" encoding="UTF-8" indent="no"/>
	<!--   saxon:next-in-chain="vorprozess2.xsl"	-->
	<xsl:strip-space elements="*"/>
	<xsl:template match="/">
		<xsl:processing-instruction name="d2t-uri" select="document-uri(/)"/>
		<xsl:apply-templates/>
	</xsl:template>
	<xsl:template
		match="aml:annotation[@w:type='Word.Deletion']
        |aml:annotation[@w:type='Word.Formatting']
        |w:p[w:pPr//aml:annotation[@w:type='Word.Deletion']]
        |w:r[w:rPr//aml:annotation[@w:type='Word.Deletion']]
        |w:tc[w:tcPr//aml:annotation[@w:type='Word.Deletion']]
        |w:tr[w:trPr//aml:annotation[@w:type='Word.Deletion']]
        |w:tbl[w:tblPr//aml:annotation[@w:type='Word.Deletion']]
        |w:r[aml:annotation[@w:type='Word.Comment']]"/>
	<xsl:template match="aml:annotation" priority="-1"/>
	<xsl:template match="aml:annotation[@w:type='Word.Insertion']|aml:content">
		<xsl:apply-templates/>
	</xsl:template>
	<xsl:template match="node() | @*" priority="-5">
		<xsl:copy>
			<xsl:apply-templates select="node() | @*"/>
		</xsl:copy>
	</xsl:template>
</xsl:stylesheet>
