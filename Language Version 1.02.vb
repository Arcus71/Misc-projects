'Language test version 1.02 By Archie J. Piatt
Imports System, system.Console, system.Threading.Thread, system.ConsoleColor

Module ProgramTheFirst
        'Global variables
    'General stuff
    Dim userLine As string = "empty" 'Stores user input
    Dim linesExecuted As integer = 1 'Count of what line you are on
    Dim exitExecute As boolean = false 'Says when to exit the loop
    
    'Looks
    Dim textColour As ConsoleColor = Black
    Dim highlightsColour As Consolecolor = Red
    
    'Variable control
    Dim variables As new Dictionary(Of string, integer) 'Store all custom variables in a dictionary structure
    
    Sub Main()
        do while (exitExecute = false)
            ForegroundColor = highlightsColour
            Write(linesExecuted & ": ") 'Write and get input
            ForegroundColor = textColour
            userLine = readline()
            
            'Testing for inputs
            if (ifContains(userLine, "help"))
                helpCommand()
            End If
            if (ifContains(userLine,"clear"))
                clearCommand()
            End If
            if (ifContains(userLine, "tcolour"))
                tcolourCommand()
            End If
            if (ifContains(userLine, "hcolour"))
                hcolourCommand()
            End If
            if (ifContains(userLine, "pause"))
                pauseCommand()
            End If
            if (ifContains(userLine,"define"))
                defineCommand()
            End If
            if (ifContains(userLine, "increment"))
                incrementCommand()
            End If
            if (ifContains(userLine, "set"))
                setCommand()
            End If
            if (ifContains(userLine,"retrieve"))
                retrieveCommand()
            End If
            if (ifContains(userLine, "time"))
                timeCommand()
            End if
            if (ifContains(userLine, "exit"))
                exitCommand()
            End if
            linesExecuted += 1
        Loop
    End Sub
    
    Function ifContains(Byval start As String, byVal test As String) As Boolean
        return start.Contains(test)
        'Returns true if string contains test
        'Returns false if not
    End Function
    
    Sub helpCommand() 
        writeHelp("help", "Lists all available commands")
        writeHelp("clear", "Wipes code runner")
        ForegroundColor = highlightsColour
        Write(vbTab & "tcolour")
        ForegroundColor = textColour
        Write(" - Changes the default text colour [")
        ForegroundColor = Black
        Write("1")
        ForegroundColor = textColour
        Write("|")
        ForegroundColor = Darkred
        Write("2")
        ForegroundColor = textColour
        Write("|")
        ForegroundColor = DarkMagenta
        Write("3")
        ForegroundColor = textColour
        Write("|")
        ForegroundColor = DarkCyan
        Write("4")
        ForegroundColor = textColour
        Writeline("]")
        ForegroundColor = highlightsColour
        Write(vbTab & "hcolour")
        ForegroundColor = textColour
        Write(" - Changes the highlighted text colour [")
        ForegroundColor = Red
        Write("1")
        ForegroundColor = textColour
        Write("|")
        ForegroundColor = Magenta
        Write("2")
        ForegroundColor = textColour
        Write("|")
        ForegroundColor = Cyan
        Write("3")
        ForegroundColor = textColour
        Writeline("]")
        writeHelp("hcolour", "Changes the highlight colour [1|2|3]")
        writeHelp("pause [x]", "Waits [x] amount of milliseconds")
        WriteLine()
        writeHelp("define [x]", "Creates integer [x] default to 0")
        writeHelp("increment [x]", "Increases the value of [x] by 1")
        writeHelp("set [x] to [y]", "Changes value of integer [x]")
        writehelp("retrieve [x]", "Writes value of integer [x]")
        WriteLine()
        writeHelp("time", "Writes the current time")
        writeHelp("exit", "Exits code runner")
    End Sub
    
    Sub clearCommand()
        Console.Clear()
        linesExecuted = 0
    End Sub
    
    Sub tcolourCommand()
        Dim tempraryTag As integer = userLine.Replace("tcolour ", Nothing)
        if (tempraryTag = 1)
            textColour = Black
        ElseIf (tempraryTag = 2)
            textColour = DarkRed
        ElseIf(tempraryTag = 3)
            textColour = DarkMagenta
        Else
            textColour = DarkCyan
        End If
    End Sub
    
    Sub hcolourCommand()
        Dim tempraryTag As integer = userLine.Replace("hcolour ", Nothing)
        if (tempraryTag = 1)
            highlightsColour = Red
        ElseIf (tempraryTag = 2)
            highlightsColour = Magenta
        Else
            highlightsColour = Cyan
        End If
    End Sub
    
    Sub pauseCommand()
        sleep(userline.Replace("pause ", nothing))
    End Sub
    
    Sub defineCommand()
        variables.Add(userline.Replace("define ", nothing), 0)
    End Sub
    
    Sub incrementCommand()
        variables(userline.Replace("increment ", nothing)) += 1
    End Sub
    
    Sub setCommand()
        
    End Sub
    
    Sub retrieveCommand()
        Dim tempTag As string = userline.Replace("retrieve ", nothing)
        ForegroundColor = highlightsColour
        Write(vbTab & tempTag & ": ")
        ForegroundColor = textColour
        WriteLine(variables.Item(tempTag))
    End Sub
    
    Sub timeCommand()
        Dim time as Date = Date.now
        ForegroundColor = highlightsColour
        Write(vbTab & "Current time: ")
        ForegroundColor = textColour
        WriteLine(time)
    End Sub
    
    Sub exitCommand()
        exitExecute = true
    End Sub
    
    Sub writeHelp (Byval command As String, Byval context As String)
        ForegroundColor = highlightsColour
        Write(vbTab & command)
        ForegroundColor = textColour
        WriteLine(" - " & context)
    End Sub
End Module