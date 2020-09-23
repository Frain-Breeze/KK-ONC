extends Node

signal NEW_QUESTION()
signal NEW_ROUND(roundVar)

class QUESTION:
	var answer1: String
	var answer2: String
	var answer3: String
	var answer4: String
	var question: String

class ROUND:
	var questions = []
	var roundName: String

export var content = []
var csvFile = File.new()
export var currentRound = 0
export var currentQuestion = 0

func loadFile():
	print(OS.get_user_data_dir())
	print(OS.get_executable_path())
	print(csvFile.open("res://questions/loli.csv", File.READ))
	
	var inRound = false
	var tRound = ROUND.new()
	var tQuest = QUESTION.new()
	
	while(!csvFile.eof_reached()):
		var cstr = csvFile.get_csv_line(";")
		if(inRound and cstr[0] == ""): #end of questions for this round
			inRound = false
			#content.append(tRound)
			content.append(tRound)
			tRound = ROUND.new()
			tRound.questions.clear() #empty the array for the next round
		
		if(!inRound and cstr[0] != ""): #start of new round
			inRound = true
			tRound.roundName = cstr[0]
		elif(inRound): #this line has questions
			tQuest.question = cstr[0]
			tQuest.answer1 = cstr[1]
			tQuest.answer2 = cstr[2]
			tQuest.answer3 = cstr[3]
			tQuest.answer4 = cstr[4]
			#tRound.questions.append(tQuest)
			tRound.questions.append(tQuest)
			tQuest = QUESTION.new()
	
	if(inRound): #if we reached the end of the file without finishing the last round
		content.append(tRound)

func _ready():
	loadFile()
	#emit_signal("NEW_ROUND", content[currentQuestion])

func _process(delta):
	if Input.is_action_just_pressed("advance_round"):
		emit_signal("NEW_ROUND", content[currentRound])
		currentRound+=1
	
	if Input.is_action_just_pressed("team1_button1"):
		emit_signal("NEW_QUESTION")
