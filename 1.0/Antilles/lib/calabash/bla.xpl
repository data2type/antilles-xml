<p:declare-step xmlns:p="http://www.w3.org/ns/xproc" name="myPipeline">
    <p:input port="source">
        <p:document href="Europa.xml"/>
    </p:input>
    <p:output port="result">
        <p:pipe step="step2" port="result"/>
    </p:output>
    <p:rename match="EUROPA/LAND/KFZ-KENNZEICHEN" new-name="KENNZEICHEN" name="step1"/>
    <p:store href="Ergebnis.xml" name="step2"/>
</p:declare-step>
