#define   Name       "Neuromaze"
; ������ ����������
#define   Version    "0.1.0"
; �����-�����������
#define   Publisher  "Alpha 1"
; ��� ������������ ������
#define   ExeName    "Alpha 1.exe"
[Setup]

; ���������� ������������� ����������, 
;��������������� ����� Tools -> Generate GUID
AppId={{64C4AA8A-37AB-4D4D-9497-EEE3B740A902}

; ������ ����������, ������������ ��� ���������
AppName={#Name}
AppVersion={#Version}
AppPublisher={#Publisher}

; ���� ��������� ��-���������
DefaultDirName={pf}\{#Name}
; ��� ������ � ���� "����"
DefaultGroupName={#Name}

; �������, ���� ����� ������� ��������� setup � ��� ������������ �����
OutputDir=F:\������\NeuroGame\
OutputBaseFileName=NeuromazeSetup

; ���� ������                                                     s
SetupIconFile=F:\������\NeuroGame\Alpha 1\Nicon.ico

; ��������� ������
Compression=lzma
SolidCompression=yes
[Tasks]
; �������� ������ �� ������� �����
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked

[Files]

; ����������� ����
Source: "F:\������\NeuroGame\Alpha 1\Alpha 1.exe"; DestDir: "{app}"; Flags: ignoreversion

; ������������� �������
Source: "F:\������\NeuroGame\Alpha 1\*"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs
[Icons]

Name: "{group}\{#Name}"; Filename: "{app}\{#ExeName}"

Name: "{commondesktop}\{#Name}"; Filename: "{app}\{#ExeName}"; Tasks: desktopicon