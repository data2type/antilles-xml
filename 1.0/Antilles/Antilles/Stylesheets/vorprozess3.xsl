<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
	xmlns:d2t="http://www.data2type.de/word" xmlns:xs="http://www.w3.org/2001/XMLSchema"
	xmlns:xd="http://www.oxygenxml.com/ns/doc/xsl" xmlns:saxon="http://saxon.sf.net/"
	exclude-result-prefixes="xs xd saxon" version="2.0">
	<xd:doc scope="stylesheet">
		<xd:desc>
			<xd:p><xd:b>Created on:</xd:b> Nov 4, 2010</xd:p>
			<xd:p><xd:b>Author:</xd:b> d2t</xd:p>
			<xd:p/>
		</xd:desc>
	</xd:doc>
	<xsl:output method="xml" version="1.0" encoding="UTF-8" indent="no"/>
	<xsl:strip-space elements="*"/>
	<!--   saxon:next-in-chain="vorprozess4.xsl"
        
        Gruppiert alle aufeinanderfolgenden gleich ausgezeichneten inzeiligen Textabschnitt zu einem inline-Element
    -->
	<xsl:template match="p">
		<xsl:copy>
			<xsl:copy-of select="@*"/>
			<xsl:for-each-group select="inline" group-adjacent="string-join(@*/name(),'|')">
				<xsl:choose>
					<xsl:when test="current-grouping-key()=''">
						<inline>
							<xsl:copy-of select="@*"/>
							<xsl:apply-templates select="current-group()/node()"/>
						</inline>
					</xsl:when>
					<xsl:otherwise>
						<inline>
							<xsl:copy-of select="@*"/>
							<xsl:apply-templates select="current-group()/node()"/>
						</inline>
					</xsl:otherwise>
				</xsl:choose>
			</xsl:for-each-group>
		</xsl:copy>
	</xsl:template>
	<!--
	Umsetzung der rowspan-Attribute
	
-->
	<xsl:template match="td">
		<xsl:copy>
			<xsl:copy-of select="@*"/>
			<xsl:if test="@rowspan">
				<!-- Ermittlung der Spaltennummer-->
				<xsl:variable name="col"
					select="count(preceding-sibling::td[not(@colspan)]) 
                + sum(preceding-sibling::td/@colspan)"/>
				<xsl:variable name="vmergeGroups">
					<!-- 
						Gruppiert alle aufeinander folgenden trs, die in der selben Spalte stehen
						Unterschieden wird in Gruppen mit @rowspan und ohne
						Die Anzahl der trs in der ersten Gruppe ist die Anzahl der zu überspannenden Zeilen 
					-->
					<xsl:for-each-group
						select="../following-sibling::tr/
							                td[count(preceding-sibling::td[not(@colspan)]) 
							                + sum(preceding-sibling::td/@colspan) = $col]"
						group-adjacent="exists(@rowspan)">
						<xsl:if test="position()=1">
							<xsl:value-of select="count(current-group())+1"/>
						</xsl:if>
					</xsl:for-each-group>
				</xsl:variable>
				<xsl:attribute name="rowspan" select="$vmergeGroups"/>
			</xsl:if>
			<xsl:apply-templates/>
		</xsl:copy>
	</xsl:template>
	<xsl:template match="td[@rowspan='selected']"/>
	<!--
        
        Kopiert alle Knoten und Attribute
    -->
	<xsl:template match="node() | @*">
		<xsl:copy>
			<xsl:apply-templates select="node() | @*"/>
		</xsl:copy>
	</xsl:template>
</xsl:stylesheet>
