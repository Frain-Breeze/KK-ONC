extends Node

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

export var autoAdvanceQuestion: bool

var content = []
var csvFile = File.new()
var currentRound = -1
var currentQuestion = -1
var rng = RandomNumberGenerator.new()
var inAnswers = false
var currMode = MODE.QUESTION

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
			print("str1 " + cstr[1])
			print("str2 " + cstr[2])
			print("str3 " + cstr[3])
			print("str4 " + cstr[4])
			tQuest.answer1 = cstr[1+((yes+0)%array.size())]
			tQuest.answer2 = cstr[1+((yes+1)%array.size())]
			tQuest.answer3 = cstr[1+((yes+2)%array.size())]
			tQuest.answer4 = cstr[1+((yes+3)%array.size())]
			print("strR1 " + tQuest.answer1)
			print("strR2 " + tQuest.answer2)
			print("strR3 " + tQuest.answer3)
			print("strR4 " + tQuest.answer4)
			print("rnd was: " + str(yes))
			
			if(yes == 0):
				tQuest.correctAnswer = 1
			elif(yes == 1):
				tQuest.correctAnswer = 4
			elif(yes == 2):
				tQuest.correctAnswer = 3
			elif(yes == 3):
				tQuest.correctAnswer = 2
			else:
				breakpoint #that's not quite right
			print("evaluated correct answer: " + str(tQuest.correctAnswer))
			#print("correctAnswer to ^: " + str(tQuest.correctAnswer+1))
			#tRound.questions.append(tQuest)
			tRound.questions.append(tQuest)
			tQuest = QUESTION.new()
	
	if(inRound): #if we reached the end of the file without finishing the last round
		content.append(tRound)

func _ready():
	rng.randomize()
	loadFile()
	#emit_signal("NEW_ROUND", content[currentRound])
	#currentRound+=1
	next_round()
	#next_question()


enum MODE{
	QUESTION,
	ANSWER,
	ROUNDEND,
	RESULTS
}

func clear_answers():
	$UI/questions/answer1/text.text = ""
	$UI/questions/answer2/text.text = ""
	$UI/questions/answer3/text.text = ""
	$UI/questions/answer4/text.text = ""

func update_labels():
#	if(content.size() <= currentRound or content[currentRound].questions.size() <= currentQuestion):
#		clear_answers()
#		if(currentRound >= content.size()): 
#			$UI/questions/question/text.text = "end of quiz"
#		elif(currentRound >= content.size()-1):
#			$UI/questions/question/text.text = "finale"
#		else:
#			$UI/questions/question/text.text = "moving on to round " + str(currentRound+2)
#		return
	
	if(currMode == MODE.QUESTION):
		clear_answers()
		$UI/questions/question/text.text = content[currentRound].questions[currentQuestion].question
	elif(currMode == MODE.ANSWER):
		$UI/questions/answer1/text.text = content[currentRound].questions[currentQuestion].answer1
		$UI/questions/answer2/text.text = content[currentRound].questions[currentQuestion].answer2
		$UI/questions/answer3/text.text = content[currentRound].questions[currentQuestion].answer3
		$UI/questions/answer4/text.text = content[currentRound].questions[currentQuestion].answer4
		$UI/questions/question/text.text = ""
	elif(currMode == MODE.ROUNDEND):
		clear_answers()
		$UI/questions/question/text.text = "end of round"

func next_round():
	currMode = MODE.QUESTION
	currentQuestion = 0
	print("NEW ROUND TRIGGERED!")
	currentRound+=1
	update_labels()

func next_question():
	currMode = MODE.QUESTION
	currentQuestion+=1
	print("next question triggered")
	update_labels()

func show_options():
	currMode = MODE.ANSWER
	print("show options triggered!")
	update_labels()

func answer_correct(team):
	print("team " + str(team) + " has correctly answered the question")
	if content[currentRound].questions.size() <= currentQuestion+1:
		currMode = MODE.ROUNDEND
		update_labels()
		return
	if(autoAdvanceQuestion):
		next_question()

func _process(delta):
	if Input.is_action_just_pressed("show_correct_answer"):
		print("correct answer: " + str(content[currentRound].questions[currentQuestion].correctAnswer))
	
	if currMode == MODE.ANSWER:
		var CA = content[currentRound].questions[currentQuestion%content[currentRound].questions.size()].correctAnswer
		if Input.is_action_just_pressed("team1_button1") and CA == 1:
			answer_correct(1)
		elif Input.is_action_just_pressed("team1_button2") and CA == 2:
			answer_correct(1)
		elif Input.is_action_just_pressed("team1_button3") and CA == 3:
			answer_correct(1)
		elif Input.is_action_just_pressed("team1_button4") and CA == 4:
			answer_correct(1)
		
		elif Input.is_action_just_pressed("team2_button1") and CA == 1:
			answer_correct(2)
		elif Input.is_action_just_pressed("team2_button2") and CA == 2:
			answer_correct(2)
		elif Input.is_action_just_pressed("team2_button3") and CA == 3:
			answer_correct(2)
		elif Input.is_action_just_pressed("team2_button4") and CA == 4:
			answer_correct(2)
	
	if Input.is_action_just_pressed("advance"):
		if(currMode == MODE.ANSWER):
			next_question()
		elif(currMode == MODE.ROUNDEND):
			next_round()
	else:
		if Input.is_action_just_pressed("advance_round"):
			next_round()
		if Input.is_action_just_pressed("advance_question"):
			show_options()
		if Input.is_action_just_pressed("new_question"):
			next_question()
