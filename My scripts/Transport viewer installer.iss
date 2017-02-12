[Setup]
AppName=Transport Viewer
AppVersion=1.0
; �������, � ������� ����������� ��������� ���������� ���������. ��������� {pf} ���������� ����� Program Files
DefaultDirName={pf}\Transport Viewer
; ��� ����� � ���� ���� �� ���������
DefaultGroupName=Transport Viewer
; ������ ���������, ������������ � ������� "��������� � �������� ��������" ������ ����������. ��������� {app} ���������� ����������, ���� ����������� ����������
UninstallDisplayIcon={app}\TransportViewer.exe
; ����� ������ ������ � �����������
Compression=lzma2
; �������� ���������� ������. ��������� �������� ������ �������� ��� ��������� ������������ �� �������� �� �����
SolidCompression=yes
; ��� �����������
OutputBaseFilename=TransportViewerSetup

[Files]
; ��������������� �����
Source: "TransportViewer.exe"; DestDir: "{app}"
Source: "ClassLibrary1.dll"; DestDir: "{app}"

[Icons]
; �������� ������ ���������� � ���� ����
Name: "{group}\Transport Viewer"; Filename: "{app}\TransportViewer.exe"; IconFilename: "{app}\TransportViewer.exe" 

[Registry]
; ����������� ���������� ����� � ������������ ��������� �� ��������� ����� ���� ����� 
Root: HKCR; Subkey: ".tl"; ValueType: string; ValueData: "tlfile"; Flags: uninsdeletekey
; ����������� ���� �����, ��������� �� ��������� ������� �������� ���������� � �����
Root: HKCR; Subkey: "tlfile"; ValueType: string; ValueData: "Transport List Document"; Flags: uninsdeletekey
; ���������� ������ ��� �����, �������� ��������� �� ��������� - ���� �� ������
Root: HKCR; Subkey: "tlfile\DefaultIcon"; ValueType: string; ValueData: "{app}\TransportViewer.exe,1"
; ����������� ���������� ������������ ����� ������������������� ����
; �������� �� ��������� ����� command ���������������� �������� ������� ����������
Root: HKCR; Subkey: "tlfile\shell"
Root: HKCR; Subkey: "tlfile\shell\open"
Root: HKCR; Subkey: "tlfile\shell\open\command"; ValueType: expandsz; ValueData: "{app}\TransportViewer.exe %1" 