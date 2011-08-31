<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="2.0" xmlns:fo="http://www.w3.org/1999/XSL/Format" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
	<xsl:output method="xml" version="1.0" indent="yes"/>
	<xsl:template match="/">
		<fo:root font-family="Helvetica, Cambria, Arial" font-size="10pt" line-height="1.2">
			<fo:layout-master-set>
				<fo:simple-page-master margin="10mm 7mm 8mm 18mm" master-name="content-pages" page-height="297mm" page-width="210mm">
					<fo:region-body margin="20mm 30mm 20mm 0mm"/>
					<fo:region-after region-name="content-after" extent="10mm" padding="0 0 0 0" border-width="0 0 0 0" display-align="before" border-before-style="solid"  />
				</fo:simple-page-master>
			</fo:layout-master-set>
			<fo:page-sequence master-reference="content-pages">
				<fo:static-content flow-name="content-after">
					<fo:block text-align="right"  margin-top="1pt" font-size="8pt">page 
               <fo:page-number/>
					</fo:block>
				</fo:static-content>
				<fo:flow flow-name="xsl-region-body">
					<fo:block>
						<xsl:apply-templates/>
					</fo:block>
				</fo:flow>
			</fo:page-sequence>
		</fo:root>
	</xsl:template>
	<xsl:template match="*">
		<fo:block color="red">[<xsl:value-of select="name()"/>]
			<xsl:apply-templates/>
		</fo:block>
	</xsl:template>
	<xsl:template match="author">
		<fo:block font-size="12pt" font-weight="bold" keep-with-next.within-page="always">
			<xsl:apply-templates/>
		</fo:block>
	</xsl:template>
	<xsl:template match="firstName">
		<xsl:apply-templates/>
		<xsl:text> </xsl:text>
	</xsl:template>
	<xsl:template match="familyName">
		<xsl:apply-templates/>
	</xsl:template>
	<xsl:template match="title">
		<fo:block font-size="16pt" font-weight="bold" space-after="10pt" keep-with-next.within-page="always">
			<xsl:apply-templates/>
		</fo:block>
	</xsl:template>
	<xsl:template match="verse">
		<fo:block  space-after="4pt" keep-together.within-page="always">
			<xsl:apply-templates/>
		</fo:block>
	</xsl:template>
	<xsl:template match="line">
		<fo:block >
			<xsl:apply-templates/>
		</fo:block>
	</xsl:template>	
	
	<xsl:template match="poem">
		<fo:block  space-after="20pt">
			<xsl:apply-templates/>
		</fo:block>
	</xsl:template>	
	<xsl:template match="bold">
		<fo:inline  font-weight="bold">
			<xsl:apply-templates/>
		</fo:inline>
	</xsl:template>	
	
	<xsl:template match="subtitle">
		<fo:block font-size="12pt" font-weight="bold" font-style="italic" keep-with-next.within-page="always">
			<xsl:apply-templates/>
		</fo:block>
	</xsl:template>	
	
	<xsl:template match="poems">
		<xsl:apply-templates/>
	</xsl:template>
	
</xsl:stylesheet>
