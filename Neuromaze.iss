#define   Name       "Neuromaze"
; Версия приложения
#define   Version    "0.1.0"
; Фирма-разработчик
#define   Publisher  "Alpha 1"
; Имя исполняемого модуля
#define   ExeName    "Alpha 1.exe"
[Setup]

; Уникальный идентификатор приложения, 
;сгенерированный через Tools -> Generate GUID
AppId={{64C4AA8A-37AB-4D4D-9497-EEE3B740A902}

; Прочая информация, отображаемая при установке
AppName={#Name}
AppVersion={#Version}
AppPublisher={#Publisher}

; Путь установки по-умолчанию
DefaultDirName={pf}\{#Name}
; Имя группы в меню "Пуск"
DefaultGroupName={#Name}

; Каталог, куда будет записан собранный setup и имя исполняемого файла
OutputDir=F:\Диплом\NeuroGame\
OutputBaseFileName=NeuromazeSetup

; Файл иконки                                                     s
SetupIconFile=F:\Диплом\NeuroGame\Alpha 1\Nicon.ico

; Параметры сжатия
Compression=lzma
SolidCompression=yes
[Tasks]
; Создание иконки на рабочем столе
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked

[Files]

; Исполняемый файл
Source: "F:\Диплом\NeuroGame\Alpha 1\Alpha 1.exe"; DestDir: "{app}"; Flags: ignoreversion

; Прилагающиеся ресурсы
Source: "F:\Диплом\NeuroGame\Alpha 1\*"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs
[Icons]

Name: "{group}\{#Name}"; Filename: "{app}\{#ExeName}"

Name: "{commondesktop}\{#Name}"; Filename: "{app}\{#ExeName}"; Tasks: desktopicon