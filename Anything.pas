{$MODE OBJFPC}

{ Color constant guide for TextColor:
  Black = 0;
  Blue = 1;
  Green = 2;
  Cyan = 3;
  Red = 4;
  Magenta = 5;
  Brown = 6;
  LightGray = 7;
  DarkGray = 8;
  LightBlue = 9;
  LightGreen = 10;
  LightCyan = 11;
  LightRed = 12;
  LightMagenta = 13;
  Yellow = 14;
  White = 15;
}

uses crt, sysutils;

type
cmd = record
         names: string;
         helpMsg: string;
         clr: byte;
      end;

var
percentage, i, cmdIdx: integer;
command, arg, fn: string;
exits: boolean; 
commands: array[1..2] of cmd;

procedure CommandsFunction(functionName: string; argz: string);
var exitCommand: boolean; value, v2: longint; cabangCommand, c2: string;
begin
    if(commands[cmdIdx].clr <> 0) then TextColor(commands[cmdIdx].clr) else TextColor(10); 
    exitCommand := false;
    case functionName of
        'sqrt': begin
                    while (exitCommand = false) do begin
                        writeln;
                        writeln('Welcome to square root calculator! Type exit to return.');
                        write('Search for sqrt of (max. 2^31-1): ');
                        readln(cabangCommand);
                        cabangCommand := lowercase(cabangCommand);
                        if(cabangCommand = 'exit') then begin
                                writeln('See you next time!');
                            break;
                        end else begin
                        try
                            value := StrToInt(cabangCommand);
                        except
                            on E : EConvertError do begin
                                writeln;
                                writeln('Your input is not supported, check again!');
                                continue;
                            end;
                        end;
                        end;
                        writeln;
                        writeln('The sqrt value of ', value, ' is ', Sqrt(value):0:2);
                    end;
                end;
        'mod':  begin
                    while (exitCommand = false) do begin
                        writeln;
                        writeln('Welcome to modulo calculator! Type exit to return.');
                        write('Calculate for mod of : ');
                        readln(cabangCommand);
                        GoToXY(wherex + 2, wherey);
                        cabangCommand := lowercase(cabangCommand);
                        if(cabangCommand = 'exit') then begin
                                writeln;
                                writeln('Alrite then!');
                            break;
                        end;
                        write(' mod ');
                        readln(c2);
                        c2 := lowercase(c2);
                        writeln;
                        if(c2 = 'exit') then begin
                                writeln;
                                writeln('Alrite then!');
                            break;
                        end else begin
                        try
                            value := StrToInt(cabangCommand);
                            v2 := StrToInt(c2);
                        except
                            on E : EConvertError do begin
                                writeln;
                                writeln('Your input is not supported, check again!');
                                continue;
                            end;
                        end;
                        end;
                        writeln('The value of ', value, ' mod ', v2, ' = ', value mod v2);
                    end;
                end;
    else
        writeln('Unrecognized command! Type ''help'' to see for a command list');
    end;
end;

procedure Loading(cd: integer);
var count, startX, y: longint;
begin
    count := 0;
    startX := wherex;
    y := wherey;
    percentage := 0;
    while(percentage < 100) do begin
        Delay(cd + random(50));
        if(percentage mod 5 = 0) then begin
            GoToXY(startX + count, y);
            write('X');
            count := count + 1;
        end;
        percentage := percentage + 1;
        GoToXY(startX + 22, y);
        write(percentage, '%');
    end;
    writeln;
end;

begin
    TextColor(9);
    commands[1].names := 'sqrt';
    commands[1].clr := 12;
    commands[1].helpMsg := 'Calculate the square root of given integer input';
    commands[2].names := 'mod';
    commands[2].clr := 14;
    commands[2].helpMsg := 'Calculate the modulo (remainder) of given integer input by another integer input';
    exits := false;
    Randomize;
    writeln('================================================');
    writeln('|++++++++++++++++++++++++++++++++++++++++++++++|');
    writeln('|+++ 0     0 EEEEEEE 0      0        OOOO +++++|');
    writeln('|+++ 0     0 E       0      0       O    O ++++|');
    writeln('|+++ 0000000 EEEEEEE 0      0      O      O +++|');
    writeln('|+++ 0     0 E       0      0       O    O ++++|');
    writeln('|+++ 0     0 EEEEEEE 000000 000000   OOOO +++++|');
    writeln('|++++++++++++++++++++++++++++++++++++++++++++++|');
    writeln('================================================');
    writeln;
    writeln('---------------------------');
    writeln('| Welcome to Utility v2.0 |');
    writeln('|    Coded by marfgold1   |');
    writeln('---------------------------');
    writeln;
    TextColor(Yellow);
    write ('Loading data: ');
    Loading(10);
    write ('Validating data: ');
    Loading(1);
    write('Cracking some shit: ');
    Loading(20);
    writeln('Done!');
    writeln;
    while(exits = false) do begin
        TextColor(7);
        cmdIdx := 0;
        writeln;
        write('Type a command to run: ');
        readln(command, arg);
        writeln;
        command := lowercase(command);
        arg := lowercase(arg);
        if(command <> 'help') and (command <> 'exit') then begin
            for i:= 1 to length(commands) do begin
                if(commands[i].names = command) then cmdIdx := i;
            end;
            CommandsFunction(commands[cmdIdx].names, arg);
        end else if(command = 'help') then begin
            writeln;
            TextColor(3);
            for i := 1 to length(commands) do begin
                writeln(commands[i].names, '   -   ', commands[i].helpMsg);
            end;
            writeln('help   -   See for command list and utility function');
            writeln('exit   -   Exit application');
        end else begin
            writeln;
            TextColor(12);
            writeln('Exiting application...');
            Loading(0);
            writeln('See you next time!');
            delay(1000);
            exits := true;
        end;
        writeln;
    end;
end.