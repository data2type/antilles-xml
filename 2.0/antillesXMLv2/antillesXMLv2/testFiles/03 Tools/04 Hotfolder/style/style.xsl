<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="2.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
	<xsl:param name="collection"/>
	<xsl:template match="poems">
		<html>
			<body>
				<h1><xsl:value-of select="$collection"/></h1>
				<xsl:apply-templates/>
			</body>
		</html>
	</xsl:template>
	<xsl:template match="author">
		<br/>
		<table>
			<col width="30px"/>
			<tbody>
				<tr>
					<td style="color:#G9G9G9;font-size:9pt">
						<xsl:number count="//title | //line | //author | //subtitle" format="1" level="any"/>
					</td>
					<td style="font-size:12pt;font-weight:bold">
						<xsl:apply-templates/>
					</td>
				</tr>
			</tbody>
		</table>
	</xsl:template>
	<xsl:template match="firstName">
		<xsl:apply-templates/>
		<xsl:text> </xsl:text>
	</xsl:template>
	<xsl:template match="familyName">
		<xsl:apply-templates/>
	</xsl:template>
	<xsl:template match="title">
		<table>
			<col width="30px"/>
			<tbody>
				<tr>
					<td style="color:#G9G9G9;font-size:9pt">
						<xsl:number count="//title | //line | //author | //subtitle" format="1" level="any"/>
					</td>
					<td style="font-size:18pt;font-weight:bold">
						<xsl:apply-templates/>
					</td>
				</tr>
			</tbody>
		</table>
	</xsl:template>
	<xsl:template match="subtitle">
		<table>
			<col width="30px"/>
			<tbody>
				<tr>
					<td style="color:#G9G9G9;font-size:9pt">
						<xsl:number count="//title | //line | //author | //subtitle" format="1" level="any"/>
					</td>
					<td style="font-size:14pt;font-weight:bold">
						<xsl:apply-templates/>
					</td>
				</tr>
			</tbody>
		</table>
	</xsl:template>
	<xsl:template match="verse">
		<p>
			<xsl:apply-templates/>
		</p>
	</xsl:template>
	<xsl:template match="line">
		<table>
			<col width="30px"/>
			<tbody>
				<tr>
					<td style="color:#G9G9G9;font-size:9pt">
						<xsl:number count="//title | //line | //author | //subtitle" format="1" level="any"/>
					</td>
					<td style="font-size:10pt;">
						<xsl:apply-templates/>
					</td>
				</tr>
			</tbody>
		</table>
	</xsl:template>
	<xsl:template match="poem">
		<br/>
		<xsl:apply-templates/>
	</xsl:template>
</xsl:stylesheet>
