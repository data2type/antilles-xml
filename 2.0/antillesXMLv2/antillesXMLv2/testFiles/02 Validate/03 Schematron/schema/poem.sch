<?xml version="1.0" encoding="UTF-8"?>
<schema xmlns="http://purl.oclc.org/dsdl/schematron" queryBinding="xslt2">
    <pattern >
        <rule context="poem">
            <report test="@publicationYear > year-from-date(current-date())">
                The publication date is in the future! 
            </report>
        </rule>
    </pattern>
</schema>