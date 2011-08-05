<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet xmlns:aml="http://schemas.microsoft.com/aml/2001/core"
    xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:xd="http://www.oxygenxml.com/ns/doc/xsl"
    xmlns:w="http://schemas.microsoft.com/office/word/2003/wordml"
    xmlns:wx="http://schemas.microsoft.com/office/word/2003/auxHint" exclude-result-prefixes="xs xd w wx"
    version="2.0">
    <xd:doc scope="stylesheet">
        <xd:desc>
            <xd:p><xd:b>Created on:</xd:b> Nov 3, 2010</xd:p>
            <xd:p><xd:b>Author:</xd:b> d2t</xd:p>
            <xd:p/>
        </xd:desc>
    </xd:doc>
    <xsl:output method="xhtml"/>
    <xsl:template match="/">
        <html>
            <head>
                <title>Mapping</title>
            </head>
            <body>
                <table>
                    <thead>
                        <tr>
                            <td class="formatName">Formatvorlage</td>
                            <td class="targetElement">Element</td>
                            <td class="option">Option</td>
                            <td class="level">Hierarchieebene</td>
                        </tr>
                    </thead>
                    <tbody class="paraFormat">
                        <xsl:for-each-group select="//w:pStyle[not(ancestor::w:footnote|ancestor::aml:annotation[@w:type='Word.Comment'])]" group-by="@w:val">
                            <tr>
                                <td class="formatName" id="{current-grouping-key()}">
                                    <xsl:variable name="style"
                                        select="/w:wordDocument/w:styles/w:style[@w:styleId=current-grouping-key()]"/>
                                    <xsl:value-of
                                        select=" if (not($style/wx:uiName/@wx:val)) 
                                        then ($style/w:name/@w:val) 
                                        else ($style/wx:uiName/@wx:val) "
                                    />
                                </td>
                                <td class="targetElement"/>
                                <td class="option"/>
                                <td class="level"/>
                            </tr>
                        </xsl:for-each-group>
                    </tbody>
                    <tbody class="lineFormat">
                        <xsl:for-each-group select="//w:rStyle[not(ancestor::w:footnote|ancestor::aml:annotation[@w:type='Word.Comment'])]" group-by="@w:val">
                            <tr>
                                <td class="formatName" id="{current-grouping-key()}">
                                    <xsl:variable name="style"
                                        select="/w:wordDocument/w:styles/w:style[@w:styleId=current-grouping-key()]"/>
                                    <xsl:value-of
                                        select="if (not($style/wx:uiName/@wx:val)) 
                                        then ($style/w:name/@w:val) 
                                        else ($style/wx:uiName/@wx:val)"
                                    />
                                </td>
                                <td class="targetElement"/>
                                <td class="option"/>
                                <td class="level"/>
                            </tr>
                        </xsl:for-each-group>
                    </tbody>
                    <xsl:call-template name="defaultElements"/>
                </table>
            </body>
        </html>
    </xsl:template>
    <xsl:template name="defaultElements">
        <tbody class="default">
            <xsl:if test=".//w:p">
                <tr>
                    <td class="formatName" id="d2t:p">Absatz</td>
                    <td class="targetElement">p</td>
                    <td class="option"/>
                    <td class="level"/>
                </tr>
            </xsl:if>
            <xsl:if test=".//w:b">
                <tr>
                    <td class="formatName" id="d2t:b">fett</td>
                    <td class="targetElement">b</td>
                    <td class="option"/>
                    <td class="level"/>
                </tr>
            </xsl:if>
            <xsl:if test=".//w:i">
                <tr>
                    <td class="formatName" id="d2t:i">kursiv</td>
                    <td class="targetElement">i</td>
                    <td class="option"/>
                    <td class="level"/>
                </tr>
            </xsl:if>
            <xsl:if test=".//w:u">
                <tr>
                    <td class="formatName" id="d2t:u">unterstrichen</td>
                    <td class="targetElement">u</td>
                    <td class="option"/>
                    <td class="level"/>
                </tr>
            </xsl:if>
            <xsl:if test=".//w:footnote">
                <tr>
                    <td class="formatName" id="d2t:footnote">Fußnoten-Element</td>
                    <td class="targetElement">fn</td>
                    <td class="option"/>
                    <td class="level"/>
                </tr>
            </xsl:if>
            <xsl:if test=".//w:tbl">
                <tr>
                    <td class="formatName" id="d2t:table">Tabelle</td>
                    <td class="targetElement">table</td>
                    <td class="option"/>
                    <td class="level"/>
                </tr>
                <xsl:if test=".//w:tbl//w:tblHeader">
                    <tr>
                        <td class="formatName" id="d2t:tbody">Tabellenkörper</td>
                        <td class="targetElement">tbody</td>
                        <td class="option"/>
                        <td class="level"/>
                    </tr>
                    <tr>
                        <td class="formatName" id="d2t:thead">Tabellenkopf</td>
                        <td class="targetElement">thead</td>
                        <td class="option"/>
                        <td class="level"/>
                    </tr>
                </xsl:if>
                <tr>
                    <td class="formatName" id="d2t:tr">Tabellenzeile</td>
                    <td class="targetElement">tr</td>
                    <td class="option"/>
                    <td class="level"/>
                </tr>
                <tr>
                    <td class="formatName" id="d2t:td">Tabellenzelle</td>
                    <td class="targetElement">td</td>
                    <td class="option"/>
                    <td class="level"/>
                </tr>
                <xsl:if test=".//w:tbl//w:gridSpan[@w:val &gt; 1]">
                    <tr>
                        <td class="formatName" id="d2t:colspan"
                            >Spaltenüberspannendes Attribut (colspan)</td>
                        <td class="targetElement">colspan</td>
                        <td class="option"/>
                        <td class="level"/>
                    </tr>
                </xsl:if>
                <xsl:if test=".//w:tbl//w:vmerge">
                    <tr>
                        <td class="formatName" id="d2t:rowspan"
                            >Zeilenüberspannendes Attribut (rowspan)</td>
                        <td class="targetElement">rowspan</td>
                        <td class="option"/>
                        <td class="level"/>
                    </tr>
                </xsl:if>
            </xsl:if>
            <xsl:if test=".//w:p//w:listPr[not(matches(wx:t/@wx:val,'.+\.'))]/w:ilfo">
                <tr>
                    <td class="formatName" id="d2t:ulistContainer"
                        >Listen-Container-Element (ungeordnet)</td>
                    <td class="targetElement">ul</td>
                    <td class="option">adjecent</td>
                    <td class="level"/>
                </tr>
            </xsl:if>
            <xsl:if test=".//w:p//w:listPr[matches(wx:t/@wx:val,'.+\.')]/w:ilfo">
                <tr>
                    <td class="formatName" id="d2t:olistContainer"
                        >Listen-Container-Element (geordnet)</td>
                    <td class="targetElement">ol</td>
                    <td class="option">adjecent</td>
                    <td class="level"/>
                </tr>
            </xsl:if>
            <xsl:if test=".//w:p//w:listPr/w:ilfo">
                <tr>
                    <td class="formatName" id="d2t:listPoint">Listen-Element</td>
                    <td class="targetElement">li</td>
                    <td class="option"/>
                    <td class="level"/>
                </tr>
            </xsl:if>
            <tr>
                <td class="formatName" id="d2t:container">Container-Element</td>
                <td class="targetElement">div</td>
                <td class="option"/>
                <td class="level"/>
            </tr>
            <tr>
                <td class="formatName" id="d2t:root">Wurzelelement</td>
                <td class="targetElement">root</td>
                <td class="option"/>
                <td class="level"/>
            </tr>
        </tbody>
    </xsl:template>
</xsl:stylesheet>
