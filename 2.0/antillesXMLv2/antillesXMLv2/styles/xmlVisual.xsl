<xsl:stylesheet version="2.0"
                xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
     >

   <xsl:output method="html"
               doctype-public="-//W3C//DTD HTML 4.1 Transitional//EN" />
 
   <xsl:param name="select" />

    
   <xsl:param name="indent-elements" select="false()" />

  
   
   <xsl:template match="/" >
      <html><head><style type="text/css" title="text/css" media="screen">
body         {  margin-left:30px;margin-top:30px; font-family: "Letter Gothic Std",monospace; color: #000000;  }
.attr-name        { color: #F5844C }
.attr-content     { color: #993300; }
.comment          { color: #006400; }
.element-name     { color: #66CBFF }
.element-nsprefix { color: #666600 }
.ns-name          { color: #0098DD }
.ns-uri           { color: #AB3100 }
.pi               { color: #8B26C9; }
.text             { color: #000000; }

      </style></head>
         <body > 
      
         <xsl:apply-templates >
            <xsl:with-param name="indent-elements" select="$indent-elements" />
         </xsl:apply-templates>
       </body>
       </html>
   </xsl:template>
 
   
   <xsl:template match="*" >
      <xsl:param name="indent-elements" select="false()" />
      <xsl:param name="indent" select="''" />
      <xsl:param name="indent-increment" select="'&#xA0;&#xA0;&#xA0;'" />
      <xsl:if test="$indent-elements">
         <br/>
         <xsl:value-of select="$indent" />
      </xsl:if>
      <xsl:text>&lt;</xsl:text>
      <xsl:variable name="ns-prefix"
                    select="substring-before(name(),':')" />
      <xsl:if test="$ns-prefix != ''">
         <span class="element-nsprefix">
            <xsl:value-of select="$ns-prefix"/>
         </span>
         <xsl:text>:</xsl:text>
      </xsl:if>
      <span class="element-name">
         <xsl:value-of select="local-name()"/>
      </span>
      <xsl:variable name="pns" select="../namespace::*"/>
      <xsl:if test="$pns[name()=''] and not(namespace::*[name()=''])">
         <span class="ns-name">
            <xsl:text> xmlns</xsl:text>
         </span>
         <xsl:text>=&quot;&quot;</xsl:text>
      </xsl:if>
      <xsl:for-each select="namespace::*">
         <xsl:if test="not($pns[name()=name(current()) and 
                           .=current()])">
            <xsl:call-template name="ns" />
         </xsl:if>
      </xsl:for-each>
      <xsl:for-each select="@*">
         <xsl:call-template name="attrs" />
      </xsl:for-each>
      <xsl:choose>
         <xsl:when test="node()">
            <xsl:text>&gt;</xsl:text>
            <xsl:apply-templates >
              <xsl:with-param name="indent-elements"
                              select="$indent-elements"/>
              <xsl:with-param name="indent"
                              select="concat($indent, $indent-increment)"/>
              <xsl:with-param name="indent-increment"
                              select="$indent-increment"/>
            </xsl:apply-templates>
            <xsl:if test="* and $indent-elements">
               <br/>
               <xsl:value-of select="$indent" />
            </xsl:if>
            <xsl:text>&lt;/</xsl:text>
            <xsl:if test="$ns-prefix != ''">
               <span class="element-nsprefix">
                  <xsl:value-of select="$ns-prefix"/>
               </span>
               <xsl:text>:</xsl:text>
            </xsl:if>
            <span class="element-name">
               <xsl:value-of select="local-name()"/>
            </span>
            <xsl:text>&gt;</xsl:text>
         </xsl:when>
         <xsl:otherwise>
            <xsl:text>/&gt;</xsl:text>
         </xsl:otherwise>
      </xsl:choose>
      <xsl:if test="not(parent::*)"><br /><xsl:text>&#xA;</xsl:text></xsl:if>
   </xsl:template>

   
   <xsl:template name="attrs">
      <xsl:text> </xsl:text>
      <span class="attr-name">
         <xsl:value-of select="name()"/>
      </span>
      <xsl:text>=&quot;</xsl:text>
      <span class="attr-content">
         <xsl:call-template name="html-replace-entities">
            <xsl:with-param name="text" select="normalize-space(.)" />
            <xsl:with-param name="attrs" select="true()" />
         </xsl:call-template>
      </span>
      <xsl:text>&quot;</xsl:text>
   </xsl:template>

   
   <xsl:template name="ns">
      <xsl:if test="name()!='xml'">
         <span class="ns-name">
            <xsl:text> xmlns</xsl:text>
            <xsl:if test="name()!=''">
               <xsl:text>:</xsl:text>
            </xsl:if>
            <xsl:value-of select="name()"/>
         </span>
         <xsl:text>=&quot;</xsl:text>
         <span class="ns-uri">
            <xsl:value-of select="."/>
         </span>
         <xsl:text>&quot;</xsl:text>
      </xsl:if>
   </xsl:template>

   
   <xsl:template match="text()" >
      <span class="text">
         <xsl:call-template name="preformatted-output">
            <xsl:with-param name="text">
               <xsl:call-template name="html-replace-entities">
                  <xsl:with-param name="text" select="." />
               </xsl:call-template>
            </xsl:with-param>
         </xsl:call-template>
      </span>
   </xsl:template>

   
   <xsl:template match="comment()" >
      <xsl:text>&lt;!--</xsl:text>
      <span class="comment">
         <xsl:call-template name="preformatted-output">
            <xsl:with-param name="text" select="." />
         </xsl:call-template>
      </span>
      <xsl:text>--&gt;</xsl:text>
      <xsl:if test="not(parent::*)"><br/><xsl:text>&#xA;</xsl:text></xsl:if>
   </xsl:template>

   
   <xsl:template match="processing-instruction()" >
      <xsl:text>&lt;?</xsl:text>
      <span class="pi">
         <xsl:value-of select="name()"/>
      </span>
      <xsl:if test=".!=''">
         <xsl:text> </xsl:text>
         <span class="pi">
            <xsl:value-of select="."/>
         </span>
      </xsl:if>
      <xsl:text>?&gt;</xsl:text>
      <xsl:if test="not(parent::*)"><br/><xsl:text>&#xA;</xsl:text></xsl:if>
   </xsl:template>


   
   
   

   
   <xsl:template name="html-replace-entities">
      <xsl:param name="text" />
      <xsl:param name="attrs" />
      <xsl:variable name="tmp">
         <xsl:call-template name="replace-substring">
            <xsl:with-param name="from" select="'&gt;'" />
            <xsl:with-param name="to" select="'&amp;gt;'" />
            <xsl:with-param name="value">
               <xsl:call-template name="replace-substring">
                  <xsl:with-param name="from" select="'&lt;'" />
                  <xsl:with-param name="to" select="'&amp;lt;'" />
                  <xsl:with-param name="value">
                     <xsl:call-template name="replace-substring">
                        <xsl:with-param name="from" 
                                        select="'&amp;'" />
                        <xsl:with-param name="to" 
                                        select="'&amp;amp;'" />
                        <xsl:with-param name="value" 
                                        select="$text" />
                     </xsl:call-template>
                  </xsl:with-param>
               </xsl:call-template>
            </xsl:with-param>
         </xsl:call-template>
      </xsl:variable>
      <xsl:choose>
         
         <xsl:when test="$attrs">
            <xsl:call-template name="replace-substring">
               <xsl:with-param name="from" select="'&#xA;'" />
               <xsl:with-param name="to" select="'&amp;#xA;'" />
               <xsl:with-param name="value">
                  <xsl:call-template name="replace-substring">
                     <xsl:with-param name="from" 
                                     select="'&quot;'" />
                     <xsl:with-param name="to" 
                                     select="'&amp;quot;'" />
                     <xsl:with-param name="value" select="$tmp" />
                  </xsl:call-template>
               </xsl:with-param>
            </xsl:call-template>
         </xsl:when>
         <xsl:otherwise>
            <xsl:value-of select="$tmp" />
         </xsl:otherwise>
      </xsl:choose>
   </xsl:template>

   
   <xsl:template name="replace-substring">
      <xsl:param name="value" />
      <xsl:param name="from" />
      <xsl:param name="to" />
      <xsl:choose>
         <xsl:when test="contains($value,$from)">
            <xsl:value-of select="substring-before($value,$from)" />
            <xsl:value-of select="$to" />
            <xsl:call-template name="replace-substring">
               <xsl:with-param name="value" 
                               select="substring-after($value,$from)" />
               <xsl:with-param name="from" select="$from" />
               <xsl:with-param name="to" select="$to" />
            </xsl:call-template>
         </xsl:when>
         <xsl:otherwise>
            <xsl:value-of select="$value" />
         </xsl:otherwise>
      </xsl:choose>
   </xsl:template>

   <!-- preformatted output: space as &nbsp;, tab as 8 &nbsp;
                             nl as <br> -->
   <xsl:template name="preformatted-output">
      <xsl:param name="text" />
      <xsl:call-template name="output-nl">
         <xsl:with-param name="text">
            <xsl:call-template name="replace-substring">
               <xsl:with-param name="value"
                               select="translate($text,' ','&#xA0;')" />
               <xsl:with-param name="from" select="'&#9;'" />
               <xsl:with-param name="to" 
                               select="'&#xA0;&#xA0;&#xA0;&#xA0;'" />
            </xsl:call-template>
         </xsl:with-param>
      </xsl:call-template>
   </xsl:template>

   
   <xsl:template name="output-nl">
      <xsl:param name="text" />
      <xsl:choose>
         <xsl:when test="contains($text,'&#xA;')">
            <xsl:value-of select="substring-before($text,'&#xA;')" />
            <br />
            <xsl:text>&#xA;</xsl:text>
            <xsl:call-template name="output-nl">
               <xsl:with-param name="text" 
                               select="substring-after($text,'&#xA;')" />
            </xsl:call-template>
         </xsl:when>
         <xsl:otherwise>
            <xsl:value-of select="$text" />
         </xsl:otherwise>
      </xsl:choose>
   </xsl:template>
 

   <xsl:template match="*" mode="xmlverbwrapper">
      <xsl:choose>
         <xsl:when test="name()=$select">
            
            
            <span class="text">
               <xsl:call-template name="preformatted-output">
                  <xsl:with-param name="text">
                     <xsl:call-template name="find-last-line">
                        <xsl:with-param name="text"
                              select="preceding-sibling::node()[1][self::text()]" />
                     </xsl:call-template>
                  </xsl:with-param>
               </xsl:call-template>
            </span>
            
            <xsl:apply-templates select="."  />
            <br /><br />
         </xsl:when>
         <xsl:otherwise>
            
            <xsl:apply-templates select="*" mode="xmlverbwrapper" />
         </xsl:otherwise>
      </xsl:choose>
   </xsl:template>

   
   <xsl:template name="find-last-line">
      <xsl:param name="text" />
      <xsl:choose>
         <xsl:when test="contains($text,'&#xA;')">
            <xsl:call-template name="find-last-line">
               <xsl:with-param name="text"
                    select="substring-after($text,'&#xA;')" />
            </xsl:call-template>
         </xsl:when>
         <xsl:otherwise>
            <xsl:value-of select="$text" />
         </xsl:otherwise>
      </xsl:choose>
   </xsl:template>

</xsl:stylesheet>
