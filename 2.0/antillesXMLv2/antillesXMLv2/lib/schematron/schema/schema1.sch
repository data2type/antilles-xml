<?xml version="1.0" encoding="UTF-8"?><schema xmlns="http://purl.oclc.org/dsdl/schematron" xmlns:fn="http://www.w3.org/2005/xpath-functions" queryBinding="xslt">
	<title>T0 - Schematron</title>
	
	<ns prefix="sch" uri="http://purl.oclc.org/dsdl/schematron"/>
	<ns prefix="fn" uri="http://www.w3.org/2005/xpath-functions"/>
	<!--*********************************************************************
		**
		**  Phases 
		** 
	-->
	
	<phase id="developer"> 
		<active pattern="_5abschnittMapping"/>
		<active pattern="_6Silbentrennung"/>
		<active pattern="_7Unterstriche"/>
		<active pattern="_8Tabellen"/>
		<active pattern="_9MediRegZeichen"/>
		<active pattern="_11FalscheSofthyphen"/>
		<active pattern="_12Listen"/> 
		<active pattern="_14HinweisBeiFragebogen"/>
		<active pattern="_15IndividuellerAntworttext"/>
		<active pattern="_16Fragezeichen"/>
		<active pattern="_17Rekursionen"/>
		<active pattern="_18LeereInzeilige"/>
		<active pattern="_19aMicroTypo_Gedankenstrich"/>
		<active pattern="_19bMicroTypo_B_in_B"/>
		<active pattern="_19cMicroTypo_mehrere_br"/>
		<active pattern="_20ElementeNurMitLeerzeichen"/>
		<active pattern="_21SlashMitLeerzeichen"/> 
		<active pattern="_23LeereAbsätze"/>  
	</phase>
	<phase id="author">
		<active pattern="_3PIs"/>  
		
		<active pattern="_4Comment"/> 
	</phase>
	<!--*********************************************************************
		**
		**  Patterns 
		** 
	--> 
	
	<pattern id="_3PIs">
		<rule context="processing-instruction()">
			<let name="Inhalt" value="."/>
			<assert test="not(name()='fehler')"><value-of select="$Inhalt"/></assert>
			<assert test="not(name()='lesehinweis')"><value-of select="$Inhalt"/></assert>
		</rule>
	</pattern>
	
	<pattern id="_4Comment">
		<rule context="comment()">
			<assert test="not(contains(.,'d2t'))">Wenn Sie diesen Kommentar weiterhin brauchen bitte einfach d2t löschen!</assert>
			 
		</rule>
	</pattern>
	
	 
	
	<pattern id="_4Fussnoten">
		<rule context="*">
			<assert test="not(contains(./text(), '*'))">Sternchen in Fließtext weißt auf Fussnote hin! Vor
				einer Fussnote ist ein Sternchen nicht mehr notwendig!</assert>
			<!--      <assert test="not(contains(sup/text(), '*'))">Bei einer Fussnote wird das Fussnotenzeichen nicht mehr mit sup hochgestellt!</assert>-->
		</rule>
	</pattern>
	
	<pattern id="_5abschnittMapping">
		<rule context="fehler/abschnitt">
			<assert test="false()">Den Titel "<value-of select="titel"/>" in eine Liste mit Dateinamen eintragen für das zu erweiternde Mapping.</assert>
		</rule>
	</pattern>
	
	<pattern id="_6Silbentrennung">
		<rule context="*[normalize-space(./text())]">
			<assert test="not(contains(., '­ '))">Silbentrennung nur mit Hilfe der Entity
				"­". OHNE Leerstelle nach der Entity!</assert>
			<assert test="(not(contains(., '­­')))">Silbentrennung nur mit Hilfe der
				Entity "­". Diese Entity wird NICHT doppelt verwendet!</assert>
			<assert test="not(substring(br/preceding-sibling::text()[1],string-length(br/preceding-sibling::text()[1]))='-')">Silbentrennung mit -&lt;br/&gt;, wenn text-text dann fehler, wenn text-Text dann
				kein Fehler. </assert>
			 
		 
			
		</rule>
	</pattern>
	
	<pattern id="_7Unterstriche">
		<rule context="a | i | b | s | sup | sub  | reg | sgv | frage-an-autoren | aenderung | medikament | feld | kurztitel | kurztext |    empfohlen-von | herausgeber | fgherausgeber | autoren | illustrationen | titel | fragetext  | fragezusatz | ind-antworttext | themen | leerzeile">
			<assert test="not(contains(./text(), '__'))">Statt Unterstrichen sollte das Element "leerzeile
				mit dem Attrbute laenge="XXmm"/" verwendet werden!</assert>
		</rule>
	</pattern>
	
	
	<pattern id="_8Tabellen">
		<rule context="table">
			<assert test="not(contains(.//text(), ' '))">Die Spaltenbreite einer Tabelle wird
				in "table" über das Kindelement "col width="" geregelt, NICHT mit festen
				Leerzeichen!</assert>
		</rule>
	</pattern>
	
	<pattern id="_9MediRegZeichen">
		<rule context="*">
			<assert test="not(contains(text(), '®'))">Das Registriert-Zeichen (Unicode #x00AE) soll nicht
				in dem Element sup direkt nach einem medikament (text) erscheinen! Bitte löschen und
				medikament als &lt;medikament&gt; taggen.</assert>
		</rule>
	</pattern>
	 
	<pattern id="_11FalscheSofthyphen">
		<rule context="*">
			<assert test="not(contains(./text(), '­ '))">In Fließtext darf auf ein Softhyphen
				KEIN Leerzeichen folgen!</assert>
			<assert test="not(contains(./text(), '­­'))">Es dürfen keine DOPPELTEN
				Softhyphen in Text enthalten sein!</assert>
		</rule>
	</pattern>
	
	<pattern id="_12Listen">
		<rule context="ul">
			<assert test="not(preceding-sibling::ul)">Das Element "ul" darf nicht für jeden Listenpunkt
				erzeugt werden! Ein "ul" umspannt mehrere Listenpunkte "li"!</assert>
		</rule>
		<rule context="li">
			<assert test="./a">Listenpunkt "li" muss als Kindelement "a" enthalten!</assert>
		</rule>
		<rule context="td">
			<assert test="not(.//box)">Tabelle darf nicht über "td/a/box" als Liste missbraucht werden.
				Statt table/tbody/etc. Inhalt mit "ul/li/a" strukturieren!</assert>
		</rule>
	</pattern>
	 
	
	<pattern id="_14HinweisBeiFragebogen">
		<rule context="*">
			<assert test="not(contains(., 'N =         Nein  J = Ja'))">In Element
				"aufforderung" darf der Antwort Ja/Nein nicht mit "festen Leerzeichen"(Entity #x00A0)
				strukuriert werden! Korrekt ist es die Angaben "N = Nein(2x Entity #x00A0)J = Ja" in einem
				neuen "a"-Element einzutragen.</assert>
		</rule>
	</pattern>
	
	<pattern id="_15IndividuellerAntworttext">
		<rule context="fragetext">
			 
			<assert test="not(contains(., '·'))">Aufzählung gehört nich in das Element
				fragetext! Die Aufzählung der Zahlen muss in das Element ind-antworttext eingebaut und zw.
				den Zahlen Leerzeichen,Entity · (#x00B7), Leerzeichen verwendet werden! </assert>
		</rule>
	</pattern>
	
	<pattern id="_16Fragezeichen">
		<rule context="*">
			<assert test="not(contains(./text(), '??'))">Mehrere Fragezeichen deuten auf ein Problem
				hin!</assert>
		</rule>
	</pattern>
	
	<pattern id="_17Rekursionen">
		<rule context="sgv">
			<assert test="not(./ancestor::sgv)">Rekursion von sgv!</assert>
		</rule>
		<rule context="b">
			<assert test="not(./ancestor::b)">Rekursion von b!</assert>
		</rule> 
		<rule context="leerzeile">
			<assert test="not(./ancestor::leerzeile)">Rekursion von leerzeile!</assert>
		</rule>
		<rule context="aenderung">
			<assert test="not(./ancestor::aenderung)">Rekursion von aenderung!</assert>
		</rule>
	</pattern>
	
	<pattern id="_18LeereInzeilige">
		<rule context="i | b | s | sup | sub |  reg | sgv">
			<assert test=".//text()">Leeres inzeiliges Element!</assert>
		</rule>
	</pattern>
	
	<pattern id="_19aMicroTypo_Gedankenstrich">
		<rule context="*">
			<assert test="not(contains(.//text(), ' - '))">Gedankenstrich mit der richtigen Unicode-Entity
				–(#x2013 Halbgeviertstrich) schreiben!</assert>
		</rule>
	</pattern>
	
	<pattern id="_19bMicroTypo_B_in_B">
		<rule context="*">
			<assert test="not(//b//*//b)">B in B über mehrere Hierarchien!</assert>
		</rule>
	</pattern>
	
	<pattern id="_19cMicroTypo_mehrere_br">
		<rule context="*">
			<assert test="not(//br[following-sibling::node()[1][self::br]])">Mehrere br's
				hintereinander!</assert>
		</rule>
	</pattern>
	
	<pattern id="_20ElementeNurMitLeerzeichen">
		<rule context="*">
			<assert test="not(count(child::node())=1 and text()=' ')">Elemente, das nur Leerzeichen
				enthält! Element als leeres Element beschreiben!</assert>
		</rule>
	</pattern>
	
	<pattern id="_21SlashMitLeerzeichen">
		<rule context="*">
			<assert test="not(contains(text(),' / '))">Leerstellen vor und nach Slash löschen. Beispiel:
				Ärztin / Arzt ... wird zu Ärztin/Arzt!</assert>
		</rule>
	</pattern>
	  
	
	<pattern id="_23LeereAbsätze"> 
		<rule context="a[not(*)] | fragetext[not(*)] | abschnitt[not(*)]">
			<assert test="not(normalize-space(text())='')">Leere Absätze, Fragetexte und Abschnitte bitte löschen!</assert>
		</rule>
	</pattern>  
	
</schema>