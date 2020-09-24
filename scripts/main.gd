extends Node

signal NEW_QUESTION()
signal ADVANCE_ANSWER()
signal NEW_ROUND(roundVar)

class QUESTION:
	var answer1: String
	var answer2: String
	var answer3: String
	var answer4: String
	var question: String
	var correctAnswer

class ROUND:
	var questions = []
	var roundName: String

export var content = []
var csvFile = File.new()
export var currentRound = 0
export var currentQuestion = 0
var rng = RandomNumberGenerator.new()

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
			var array = [0,1,2,3]
			#var yes = array[rng.randi()%array.size()]
			var yes = rng.randi_range(0,3)
			#var yes = 4
			#tQuest.correctAnswer = cstr[1]
			tQuest.correctAnswer = abs(3-(yes%4))
			print("1:" + str((yes+0)%array.size()))
			print("2:" + str((yes+1)%array.size()))
			print("3:" + str((yes+2)%array.size()))
			print("4:" + str((yes+3)%array.size()))
			#tQuest.answer1 = cstr[1]
			#tQuest.answer2 = cstr[2]
			#tQuest.answer3 = cstr[3]
			#tQuest.answer4 = cstr[4]
			print("arraysize: " + str(array.size()))
			tQuest.answer1 = cstr[1+((yes+0)%array.size())]
			tQuest.answer2 = cstr[1+((yes+1)%array.size())]
			tQuest.answer3 = cstr[1+((yes+2)%array.size())]
			tQuest.answer4 = cstr[1+((yes+3)%array.size())]
			#tRound.questions.append(tQuest)
			tRound.questions.append(tQuest)
			tQuest = QUESTION.new()
	
	if(inRound): #if we reached the end of the file without finishing the last round
		content.append(tRound)

func _ready():
	rng.randomize()
	loadFile()
	emit_signal("NEW_ROUND", content[currentRound])
	currentRound+=1

#order of signals:
#1 advance_round (load new round)
#2 advance_answer (go to the answer)
#3 advance_question (go to the next question)
#4 repeat 2 and 3 until all questions are done, then move to 1

func _process(delta):
	if Input.is_action_just_pressed("show_correct_answer"):
		print("correct answer: " + str(content[currentRound].questions[currentQuestion].correctAnswer))
	
	if Input.is_action_just_pressed("team1_button1") and content[currentRound].questions[currentQuestion-1].correctAnswer == 0:
		print("team1_button1")
	if Input.is_action_just_pressed("team1_button2") and content[currentRound].questions[currentQuestion-1].correctAnswer == 1:
		print("team1_button2")
	if Input.is_action_just_pressed("team1_button3") and content[currentRound].questions[currentQuestion-1].correctAnswer == 2:
		print("team1_button3")
	if Input.is_action_just_pressed("team1_button4") and content[currentRound].questions[currentQuestion-1].correctAnswer == 3:
		print("team1_button4")
	
	if Input.is_action_just_pressed("team2_button1") and content[currentRound].questions[currentQuestion-1].correctAnswer == 0:
		print("team2_button1")
	if Input.is_action_just_pressed("team2_button2") and content[currentRound].questions[currentQuestion-1].correctAnswer == 1:
		print("team2_button2")
	if Input.is_action_just_pressed("team2_button3") and content[currentRound].questions[currentQuestion-1].correctAnswer == 2:
		print("team2_button3")
	if Input.is_action_just_pressed("team2_button4") and content[currentRound].questions[currentQuestion-1].correctAnswer == 3:
		print("team2_button4")
	
	
	
	if Input.is_action_just_pressed("advance_round"):
		emit_signal("NEW_ROUND", content[currentRound])
		currentRound+=1
	
	if Input.is_action_just_pressed("advance_question"):
		emit_signal("ADVANCE_ANSWER")
		currentQuestion+=1
		print(content[currentRound].questions[currentQuestion].correctAnswer)
	
	
	if Input.is_action_just_pressed("new_question"):
		emit_signal("NEW_QUESTION")
	
