<p:declare-step xmlns:p="http://www.w3.org/ns/xproc" name="myPipeline">
    <p:input port="source">
        <p:document href="poem.xml"/>
    </p:input>
    <p:output port="result">
        <p:pipe step="step1" port="result"/>
    </p:output>
    <p:xslt name="step1">
        <p:input port="source"/>
        <p:input port="stylesheet">
            <p:document href="style.xsl"/>
        </p:input>
        <p:input port="parameters">
            <p:empty/>
        </p:input>
    </p:xslt>
    <p:store href="result.xml" name="step2"/>
</p:declare-step>
