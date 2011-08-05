<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:d2t="http://www.data2type.de/word"
	xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:xd="http://www.oxygenxml.com/ns/doc/xsl"
	xmlns:saxon="http://saxon.sf.net/" exclude-result-prefixes="xs xd saxon" version="2.0">
	<xd:doc scope="stylesheet">
		<xd:desc>
			<xd:p><xd:b>Created on:</xd:b> Jan 12, 2011</xd:p>
			<xd:p><xd:b>Author:</xd:b> d2t</xd:p>
			<xd:p/>
		</xd:desc>
	</xd:doc>
	<xsl:output method="xml" version="1.0" encoding="UTF-8" indent="no"/>
<!-- saxon:next-in-chain="vorprozess7.xsl"	-->
	<!-- Elementname für einen Listenpunkt: -->
	<xsl:variable name="listElement" select="'li'"/>
	<!-- Elementname für das Container-Element ungeordneter Listen: -->
	<xsl:variable name="ulistContainerElement" select="'ul'"/>
	<!-- Elementname für das Container-Element geordneter Listen: -->
	<xsl:variable name="olistContainerElement" select="'ol'"/>
	<xsl:template match="body">
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
					<xsl:when test="number(@level) &gt; number($level)">
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
	<xsl:template match="*[local-name()='p'][@list-type='d2t:ulist' or @list-type='d2t:olist']">
		<xsl:element name="{$listElement}">
			<xsl:copy>
				<xsl:apply-templates select="@*[not(name()=('list-type','level'))]"/>
				<xsl:apply-templates/>
			</xsl:copy>
		</xsl:element>
	</xsl:template>
	<xsl:template match="@style[.='']|@list-type[.='none']"/>
	<!-- 
		kopiert alle Knoten:
	-->
	<xsl:template match="node() | @*">
		<xsl:copy>
			<xsl:apply-templates select="node() | @*"/>
		</xsl:copy>
	</xsl:template>
</xsl:stylesheet>
