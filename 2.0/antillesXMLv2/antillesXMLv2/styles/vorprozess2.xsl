<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="2.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
	xmlns:d2t="http://www.data2type.de/word" xmlns:aml="http://schemas.microsoft.com/aml/2001/core"
	xmlns:dt="uuid:C2F41010-65B3-11d1-A29F-00AA00C14882"
	xmlns:ve="http://schemas.openxmlformats.org/markup-compatibility/2006"
	xmlns:o="urn:schemas-microsoft-com:office:office" xmlns:v="urn:schemas-microsoft-com:vml"
	xmlns:w10="urn:schemas-microsoft-com:office:word"
	xmlns:w="http://schemas.microsoft.com/office/word/2003/wordml"
	xmlns:wx="http://schemas.microsoft.com/office/word/2003/auxHint"
	xmlns:wsp="http://schemas.microsoft.com/office/word/2003/wordml/sp2"
	xmlns:sl="http://schemas.microsoft.com/schemaLibrary/2003/core"
	extension-element-prefixes="wx saxon w w10 wsp sl aml dt ve o v"
	xmlns:saxon="http://saxon.sf.net/">
	<xsl:output method="xml" version="1.0" encoding="UTF-8" indent="no"/>
	<!--  saxon:next-in-chain="vorprozess3.xsl"
        
        Erzeugt ein HTML-Dokument:
            - wandelt alle w:p in p-Elemente um, gegebenfalls mit entsprechender Klasse
            - wandelt alle w:r in inline-Elemente um, gegebenenfalls mit entsprechender Klasse
            - wandelt alle w:tbl in table-Elemente um, gliedert in tbody/thead, tr und td.
    -->
	<xsl:strip-space elements="*"/>
	<!-- 
        
    Erzeugt den HTML-Rupmf
-->
	<xsl:template match="/">
		<xsl:variable name="uri" select="/processing-instruction()[name()='d2t-uri']"/>
		<doc>
			<head>
				<doc-name>
					<xsl:value-of select="tokenize($uri,'/')[last()]"/>
				</doc-name>
				<uri>
					<xsl:value-of select="$uri"/>
				</uri>
				<section-styles>
					<xsl:for-each-group select="/w:wordDocument/w:styles/w:style/w:pPr/w:outlineLvl"
						group-by="@w:val">
						<xsl:sort select="current-grouping-key()"/>
						<section-style level="{current-grouping-key()+1}">
							<xsl:for-each select="current-group()">
								<style>
            						<xsl:value-of select="ancestor::w:style/@w:styleId"/>
            					</style>
							</xsl:for-each>
						</section-style>
					</xsl:for-each-group>
				</section-styles>
			</head>
			<xsl:apply-templates select="//w:body"/>
		</doc>
	</xsl:template>
	<xsl:template match="w:body">
		<body>
			<xsl:apply-templates/>
		</body>
	</xsl:template>
	<!-- 
        
    Umsetzung der Absätze in p-Elemente
-->
	<xsl:template match="w:p">
		<xsl:choose>
			<xsl:when test="w:pPr//w:listPr/w:ilfo">
				<p>
					<xsl:attribute name="type">para</xsl:attribute>
					<xsl:attribute name="list-type"
						select="if (matches(.//w:listPr/wx:t/@wx:val,'.+\.')) 
                        then ('d2t:olist') 
                        else ('d2t:ulist')"/>
					<xsl:attribute name="style">
						<xsl:choose>
							<xsl:when test=".//w:pStyle/@w:val">
								<xsl:apply-templates select=".//w:pStyle/@w:val"/>
							</xsl:when>
							<xsl:otherwise>d2t:p</xsl:otherwise>
						</xsl:choose>
					</xsl:attribute>
					<xsl:attribute name="level" select=".//w:listPr/w:ilvl/@w:val + 1"/>
					<xsl:apply-templates select=".//w:pPr//w:b|.//w:pPr//w:i|.//w:pPr//w:u"/>
					<xsl:apply-templates select="w:r"/>
				</p>
			</xsl:when>
			<xsl:when test="w:pPr//w:pStyle">
				<xsl:variable name="style" select=".//w:pStyle/@w:val"/>
				<p>
					<xsl:attribute name="type">para</xsl:attribute>
					<xsl:attribute name="list-type">none</xsl:attribute>
					<xsl:attribute name="style">
						<xsl:apply-templates select=".//w:pStyle/@w:val"/>
					</xsl:attribute>
					<xsl:apply-templates select=".//w:pPr//w:b|.//w:pPr//w:i|.//w:pPr//w:u"/>
					<xsl:apply-templates select="w:r"/>
				</p>
			</xsl:when>
			<xsl:otherwise>
				<p>
					<xsl:attribute name="type">para</xsl:attribute>
					<xsl:attribute name="list-type">none</xsl:attribute>
					<xsl:attribute name="style">d2t:p</xsl:attribute>
					<xsl:apply-templates select=".//w:pPr//w:b|.//w:pPr//w:i|.//w:pPr//w:u"/>
					<xsl:apply-templates select="w:r|w:hlink"/>
				</p>
			</xsl:otherwise>
		</xsl:choose>
	</xsl:template>
	<xsl:template match="w:pStyle/@w:val | w:rStyle/@w:val">
		<xsl:value-of select="."/>
	</xsl:template>
	<!-- 
        
        Umsetzung der inzeiligen Auszeichnung in inline-Elementen
    -->
	<xsl:template match="w:r">
		<xsl:if test=".//w:br">
			<inline type="inline" class="d2t:br"/>
		</xsl:if>
		<xsl:choose>
			<xsl:when test="ancestor::w:hlink">
				<inline>
					<xsl:attribute name="type">inline</xsl:attribute>
					<xsl:attribute name="style">d2t:link</xsl:attribute>
					<xsl:apply-templates select=".//w:i|.//w:b|.//w:u"/>
					<xsl:apply-templates select="w:t|w:footnote"/>
				</inline>
			</xsl:when>
			<xsl:when test="w:rPr//w:rStyle">
				<inline>
					<xsl:attribute name="type">inline</xsl:attribute>
					<xsl:attribute name="style">
						<xsl:apply-templates select=".//w:rStyle/@w:val"/>
					</xsl:attribute>
					<xsl:apply-templates select=".//w:i|.//w:b|.//w:u"/>
					<xsl:apply-templates select="w:t|w:footnote"/>
				</inline>
			</xsl:when>
			<xsl:otherwise>
				<inline>
					<xsl:attribute name="type">inline</xsl:attribute>
					<xsl:apply-templates select=".//w:i|.//w:b|.//w:u"/>
					<xsl:apply-templates select="w:t|w:footnote"/>
				</inline>
			</xsl:otherwise>
		</xsl:choose>
	</xsl:template>
	<xsl:template match="w:hlink">
		<xsl:apply-templates select="w:r"/>
		<!--<inline style="d2t:link">
			<xsl:attribute name="type">inline</xsl:attribute>
			<xsl:apply-templates/>
		</inline>-->
	</xsl:template>
	<!--
        
    Einstellung der Standard-Formatierungen kursiv, fett und unterstrichen
-->
	<xsl:template match="w:i">
		<xsl:attribute name="italic">true</xsl:attribute>
	</xsl:template>
	<xsl:template match="w:b">
		<xsl:attribute name="bold">true</xsl:attribute>
	</xsl:template>
	<xsl:template match="w:u">
		<xsl:attribute name="underline">true</xsl:attribute>
	</xsl:template>
	<!--
        
    Umsetzung der Fußnoten
    -->
	<xsl:template match="w:footnote">
		<xsl:attribute name="style">d2t:footnote</xsl:attribute>
		<xsl:apply-templates select=".//w:t"/>
	</xsl:template>
	<!--
        
    Umsetzung der Tabellen, je nach w:tblHeader wird in thead oder tbody gruppiert
-->
	<xsl:template match="w:tbl">
		<table style="d2t:table">
			<xsl:for-each-group select="w:tr" group-adjacent="exists(w:trPr/w:tblHeader)">
				<xsl:choose>
					<xsl:when test="current-grouping-key()">
						<thead style="d2t:thead">
							<xsl:apply-templates select="current-group()"/>
						</thead>
					</xsl:when>
					<xsl:otherwise>
						<tbody style="d2t:tbody">
							<xsl:apply-templates select="current-group()"/>
						</tbody>
					</xsl:otherwise>
				</xsl:choose>
			</xsl:for-each-group>
		</table>
	</xsl:template>
	<xsl:template match="w:tr">
		<tr style="d2t:tr">
			<xsl:apply-templates/>
		</tr>
	</xsl:template>
	<xsl:template match="w:tc">
		<td style="d2t:td">
			<xsl:if test="w:tcPr/w:gridSpan[@w:val &gt; 1]">
				<xsl:attribute name="colspan" select="w:tcPr/w:gridSpan/@w:val"/>
			</xsl:if>
			<xsl:if test="w:tcPr/w:vmerge">
				<xsl:attribute name="rowspan"
					select=" if (w:tcPr/w:vmerge/@w:val='restart') 
                    then ('start') 
                    else ('selected')"
				/>
			</xsl:if>
			<xsl:apply-templates/>
		</td>
	</xsl:template>
	<xsl:template match="w:t">
		<xsl:value-of select="."/>
	</xsl:template>
	<xsl:template match="w:tcPr|w:trPr|w:tblPr|aml:annotation[@w:type='Word.Deletion']"/>
	<xsl:template match="*[not(self::w:t)][not(normalize-space(string-join(text(),''))='')]"/>
	<xsl:template
		match="aml:annotation[@w:type='Word.Insertion']|wx:sub-section | wx:pBdrGroup | wx:borders | *[namespace-uri()='http://schemas.microsoft.com/office/word/2003/auxHint']">
		<xsl:apply-templates/>
	</xsl:template>
	<xsl:template match="w:sectPr"/>
	<!--
        
    Kopiert alle Elemente mit Attributen
-->
	<xsl:template match="*" priority="-1">
		<xsl:apply-templates/>
		<!--<xsl:copy>
            <xsl:copy-of select="@*"/>
            <xsl:apply-templates/>
        </xsl:copy>-->
	</xsl:template>
</xsl:stylesheet>
