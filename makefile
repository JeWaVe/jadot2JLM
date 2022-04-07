dotnet:
	cd generator && dotnet run

tex:
	cd tex && latex main.tex
	cd tex && dvips main.dvi
	cd tex && ps2pdf main.ps

cleantex:
	cd tex && rm -f *.dvi && rm -f *.ps && rm -f *.aux && rm -f *.pdf && rm -f *.log

all: .PHONY

.PHONY: dotnet cleantex tex