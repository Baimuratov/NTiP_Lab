[Setup]
AppName=Transport Viewer
AppVersion=1.0
; Каталог, в который инсталлятор предложит установить программу. Константа {pf} обозначает папку Program Files
DefaultDirName={pf}\Transport Viewer
; Имя папки в меню Пуск по умолчанию
DefaultGroupName=Transport Viewer
; Значок программы, отображаемый в разделе "Установка и удаление программ" панели управления. Константа {app} обозначает директорию, куда установлено приложение
UninstallDisplayIcon={app}\TransportViewer.exe
; Метод сжатия файлов в установщике
Compression=lzma2
; Включить уплотнённое сжатие. Позволяет добиться лучшей упаковки для небольших установщиков не разбитых на диски
SolidCompression=yes
; Имя установщика
OutputBaseFilename=TransportViewerSetup

[Files]
; Устанавливаемые файлы
Source: "TransportViewer.exe"; DestDir: "{app}"
Source: "ClassLibrary1.dll"; DestDir: "{app}"

[Icons]
; Создание ярлыка приложения в меню Пуск
Name: "{group}\Transport Viewer"; Filename: "{app}\TransportViewer.exe"; IconFilename: "{app}\TransportViewer.exe" 

[Registry]
; Регистрация расширения файла и присваивание параметру по умолчанию имени типа файла 
Root: HKCR; Subkey: ".tl"; ValueType: string; ValueData: "tlfile"; Flags: uninsdeletekey
; Регистрация типа файла, параметру по умолчанию задаётся описание информации в файле
Root: HKCR; Subkey: "tlfile"; ValueType: string; ValueData: "Transport List Document"; Flags: uninsdeletekey
; Назначение иконки для файла, значение параметра по умолчанию - путь до иконки
Root: HKCR; Subkey: "tlfile\DefaultIcon"; ValueType: string; ValueData: "{app}\TransportViewer.exe,1"
; Определение приложения открывающего файлы зарегистрированного типа
; Параметр по умолчанию ключа command инициализируется командой запуска приложения
Root: HKCR; Subkey: "tlfile\shell"
Root: HKCR; Subkey: "tlfile\shell\open"
Root: HKCR; Subkey: "tlfile\shell\open\command"; ValueType: expandsz; ValueData: "{app}\TransportViewer.exe %1" 