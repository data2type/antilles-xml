<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:d2t="http://www.data2type.de/word"
	xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:xd="http://www.oxygenxml.com/ns/doc/xsl"
	xmlns:saxon="http://saxon.sf.net/" exclude-result-prefixes="xs xd saxon" version="2.0">
	<xd:doc scope="stylesheet">
		<xd:desc>
			<xd:p><xd:b>Created on:</xd:b> Jan 13, 2011</xd:p>
			<xd:p><xd:b>Author:</xd:b> d2t</xd:p>
			<xd:p/>
		</xd:desc>
	</xd:doc>
	<xsl:output method="xml" version="1.0" encoding="UTF-8" indent="no"/>
<!-- saxon:next-in-chain="vorprozess8.xsl"	-->
	<xsl:variable name="maxLevel" select="max(/doc/head/section-styles/section-style/@level)"/>
	<xsl:variable name="groupMap" select="/doc/head/section-styles/section-style"/>
	<!-- 
		erster Gruppierungsaufruf
	-->
	<xsl:template match="body">
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
		<xsl:variable name="label" select="$groupMap[@level=$level]/style"/>
		<xsl:for-each-group select="$group" group-starting-with="*[@style=$label]">
			<xsl:choose>
				<xsl:when test="current-group()[1][@style=$label]">
					<section level="{$level}">
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
					</section>
				</xsl:when>
				<xsl:otherwise>
					<xsl:apply-templates select="current-group()"/>
				</xsl:otherwise>
			</xsl:choose>
		</xsl:for-each-group>
	</xsl:template>
	<xsl:template match="@type"/>
	<xsl:template match="@style">
		<xsl:attribute name="type" select="."/>
	</xsl:template>
	<!-- 
		kopiert alle Elemente, Attribute und übrige Knoten:
	-->
	<xsl:template match="node() | @*">
		<xsl:copy>
			<xsl:apply-templates select="node() | @*"/>
		</xsl:copy>
	</xsl:template>
</xsl:stylesheet>
