extends Node

class QUESTION:
	var answer1: String
	var answer2: String
	var answer3: String
	var answer4: String
	var question: String
	var correctAnswer
	var t1ans
	var t2ans

class ROUND:
	var questions = []
	var roundName: String

export var autoAdvanceQuestion: bool
#export var questionfile = "res://questions/kk-vragen-nieuw.csv"
export var questionfile = "res://questions/kk_test.csv"
export var namefile = "res://questions/teamnames.txt"

var content = []
var csvFile = File.new()
var nameFile = File.new()
var currentRound = -1
var currentQuestion = -1
var rng = RandomNumberGenerator.new()
var currMode = MODE.QUESTION

var presname = ""
var t1names = []
var t2names = []

var scT1 = 0
var scT2 = 0

var t1answered = false
var t2answered = false

func loadFile():
	
	var mode = 0
	nameFile.open(namefile, File.READ)
	while !nameFile.eof_reached():
		var tmp = nameFile.get_line()
		print(tmp)
		if tmp == "":
			mode += 1
			continue
		if mode == 1:
			t1names.append(tmp)
		elif mode == 2:
			t2names.append(tmp)
		else:
			presname = tmp
	nameFile.close()
	
	print(OS.get_user_data_dir())
	print(OS.get_executable_path())
	print(csvFile.open(questionfile, File.READ))
	
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
			
			var corrAns = 0
			
			for n in range(1, 5):
				if cstr[n][0] == '*':
					corrAns = n
			
			print("correct answer is: " + cstr[corrAns])
			tQuest.correctAnswer = corrAns
			
			tQuest.answer1 = cstr[1].replace("*", "")
			tQuest.answer2 = cstr[2].replace("*", "")
			tQuest.answer3 = cstr[3].replace("*", "")
			tQuest.answer4 = cstr[4].replace("*", "")
			
			
			
			print("str1 " + cstr[1])
			print("str2 " + cstr[2])
			print("str3 " + cstr[3])
			print("str4 " + cstr[4])

			tRound.questions.append(tQuest)
			tQuest = QUESTION.new()
	
	csvFile.close()
	
	if(inRound): #if we reached the end of the file without finishing the last round
		content.append(tRound)

func _ready():
	rng.randomize()
	loadFile()
	clear_all()
	currMode = MODE.STARTSCREEN
	#emit_signal("NEW_ROUND", content[currentRound])
	#currentRound+=1
	#next_round()
	#next_question()


enum MODE{
	STARTSCREEN,
	INTRODUCTIONPRES,
	INTRODUCTION1,
	INTRODUCTION2,
	EMPTYSTART,
	ROUNDBEGIN,
	QUESTION,
	ANSWER,
	ROUNDEND,
	INBETWEEN,
	RESULTS,
	SHOWANSWERS,
	END
}

func clear_all():
	$UI/TextureBox/QuestionBar.visible = true
	$UI/questions/question/text.text = ""
	$UI/questions/resquestion/text.text = ""
	$UI/questions/answer1/text.text = ""
	$UI/questions/answer1/text.modulate = Color(1.0, 1.0, 1.0)
	$UI/questions/answer2/text.text = ""
	$UI/questions/answer2/text.modulate = Color(1.0, 1.0, 1.0)
	$UI/questions/answer3/text.text = ""
	$UI/questions/answer3/text.modulate = Color(1.0, 1.0, 1.0)
	$UI/questions/answer4/text.text = ""
	$UI/questions/answer4/text.modulate = Color(1.0, 1.0, 1.0)

func update_labels():
	
	if(currMode == MODE.INTRODUCTIONPRES):
		clear_all()
		$UI/questions/resquestion/text.text = "presentator:"
		$UI/questions/question/text.text = presname
	elif(currMode == MODE.INTRODUCTION1):
		clear_all()
		$UI/questions/resquestion/text.text = "team blauw:"
		for name in t1names:
			$UI/questions/question/text.text += name + " "
	elif(currMode == MODE.INTRODUCTION2):
		clear_all()
		$UI/questions/resquestion/text.text = "team rood:"
		for name in t2names:
			$UI/questions/question/text.text += name + " "
	elif(currMode == MODE.EMPTYSTART):
		clear_all()
		$UI/TextureBox/QuestionBar.visible = false
	elif(currMode == MODE.ROUNDBEGIN):
		clear_all()
		$UI/questions/question/text.text = content[currentRound].roundName
	elif(currMode == MODE.QUESTION):
		clear_all()
		if not (content[currentRound].questions.size() <= currentQuestion):
			$UI/questions/question/text.text = content[currentRound].questions[currentQuestion].question
	elif(currMode == MODE.ANSWER):
		var CQ = content[currentRound].questions[currentQuestion]
		$UI/questions/answer1/text.text = CQ.answer1
		$UI/questions/answer2/text.text = CQ.answer2
		$UI/questions/answer3/text.text = CQ.answer3
		$UI/questions/answer4/text.text = CQ.answer4
		$UI/questions/question/text.text = ""
	elif(currMode == MODE.INBETWEEN):
		clear_all()
		$UI/questions/question/text.text = ""
		$UI/questions/answer1/text.text = "score team blauw: "+str(scT1)
		$UI/questions/answer3/text.text = "score team rood: "+str(scT2)
	elif(currMode == MODE.ROUNDEND):
		clear_all()
		$UI/questions/question/text.text = "einde van " + content[currentRound].roundName
	elif(currMode == MODE.SHOWANSWERS):
		clear_all()
		$UI/questions/resquestion/text.text = content[currentRound].questions[currentQuestion].question
		
		var t1ansInt = content[currentRound].questions[currentQuestion].t1ans
		var t2ansInt = content[currentRound].questions[currentQuestion].t2ans
		
		if t1ansInt != content[currentRound].questions[currentQuestion].correctAnswer:
			$UI/questions/answer3/text.modulate = Color(0.5, 0.5, 0.5)
		if t2ansInt != content[currentRound].questions[currentQuestion].correctAnswer:
			$UI/questions/answer4/text.modulate = Color(0.5, 0.5, 0.5)
		
		$UI/questions/answer3/text.text = "team blauw: "
		if t1ansInt == 1:
			$UI/questions/answer3/text.text += content[currentRound].questions[currentQuestion].answer1
		elif t1ansInt == 2:
			$UI/questions/answer3/text.text += content[currentRound].questions[currentQuestion].answer2
		elif t1ansInt == 3:
			$UI/questions/answer3/text.text += content[currentRound].questions[currentQuestion].answer3
		elif t1ansInt == 4:
			$UI/questions/answer3/text.text += content[currentRound].questions[currentQuestion].answer4
		
		$UI/questions/answer4/text.text = "team rood: "
		if t2ansInt == 1:
			$UI/questions/answer4/text.text += content[currentRound].questions[currentQuestion].answer1
		elif t2ansInt == 2:
			$UI/questions/answer4/text.text += content[currentRound].questions[currentQuestion].answer2
		elif t2ansInt == 3:
			$UI/questions/answer4/text.text += content[currentRound].questions[currentQuestion].answer3
		elif t2ansInt == 4:
			$UI/questions/answer4/text.text += content[currentRound].questions[currentQuestion].answer4
	elif(currMode == MODE.END):
		clear_all()
		$UI/questions/question/text.text = "einde van de quiz"
		
		
		#$UI/questions/answer3/text.text = content[currentRound].questions[currentQuestion]
		#$UI/questions/answer4/text.text = content[currentRound].questions[currentQuestion%content[currentRound].questions.size()].t2ans

func next_answer():
	currentQuestion+=1
	if(content[currentRound].questions.size() <= currentQuestion):
		currMode = MODE.INBETWEEN
		update_labels()
	update_labels()
	print("curr question" + str(currentQuestion))

func next_round():
	currMode = MODE.QUESTION
	currentQuestion = 0
	print("NEW ROUND TRIGGERED!")
	currentRound+=1
	if currentRound >= content.size():
		currMode = MODE.END
		update_labels()
		return
	update_labels()
	print("curr round" + str(currentRound))

func next_question():
	t1answered = false
	t2answered = false
	currMode = MODE.QUESTION
	currentQuestion+=1
	if content[currentRound].questions.size() <= currentQuestion:
		end_of_round()
		return
	print("next question triggered")
	update_labels()

func end_of_round():
	currMode = MODE.ROUNDEND
	currentQuestion = -1
	print("end of round triggered!")
	update_labels()

func show_options():
	currMode = MODE.ANSWER
	print("show options triggered! ("+str(currentQuestion)+")")
	update_labels()

func answer_false(team, answer):
	print("team " + str(team) + " has incorrectly answered the question")
	if(team == 1):
		content[currentRound].questions[currentQuestion%content[currentRound].questions.size()].t1ans = answer
		t1answered = true
	elif(team == 2):
		content[currentRound].questions[currentQuestion%content[currentRound].questions.size()].t2ans = answer
		t2answered = true

func answer_correct(team, answer):
	print("team " + str(team) + " has correctly answered the question")
	if(team == 1):
		scT1+=1
		content[currentRound].questions[currentQuestion%content[currentRound].questions.size()].t1ans = answer
	elif(team == 2):
		scT2+=1
		content[currentRound].questions[currentQuestion%content[currentRound].questions.size()].t2ans = answer
	
	if(autoAdvanceQuestion):
		next_question()

func _process(delta):
	if Input.is_action_just_pressed("show_correct_answer"):
		print("correct answer: " + str(content[currentRound].questions[currentQuestion].correctAnswer))
	
	if currMode == MODE.ANSWER:
		if t1answered == true and t2answered == true:
			next_question()
		
		var CA = content[currentRound].questions[currentQuestion%content[currentRound].questions.size()].correctAnswer
		var CQ = content[currentRound].questions[currentQuestion]
		if t1answered == false:
			if Input.is_action_just_pressed("team1_button1"):
				if CA == 1:
					answer_correct(1, 1)
				else:
					answer_false(1, 1)
			elif Input.is_action_just_pressed("team1_button2"): 
				if CA == 2:
					answer_correct(1, 2)
				else:
					answer_false(1, 2)
			elif Input.is_action_just_pressed("team1_button3"):
				if CA == 3:
					answer_correct(1, 3)
				else:
					answer_false(1, 3)
			elif Input.is_action_just_pressed("team1_button4"):
				if CA == 4:
					answer_correct(1, 4)
				else:
					answer_false(1, 4)
		if t2answered == false:
			if Input.is_action_just_pressed("team2_button1"): 
				if CA == 1:
					answer_correct(2, 1)
				else:
					answer_false(2, 1)
			elif Input.is_action_just_pressed("team2_button2"):
				if CA == 2:
					answer_correct(2, 2)
				else:
					answer_false(2, 2)
			elif Input.is_action_just_pressed("team2_button3"):
				if CA == 3:
					answer_correct(2, 3)
				else:
					answer_false(2, 3)
			elif Input.is_action_just_pressed("team2_button4"):
				if CA == 4:
					answer_correct(2, 4)
				else:
					answer_false(2, 4)
	
	
	if Input.is_action_just_pressed("advance"):
		if(currMode == MODE.STARTSCREEN):
			$"UI/TextureBox/KK-splash".visible = false
			currMode = MODE.INTRODUCTIONPRES
			update_labels()
		elif(currMode == MODE.INTRODUCTIONPRES):
			currMode = MODE.INTRODUCTION1
			update_labels()
		elif(currMode == MODE.INTRODUCTION1):
			currMode = MODE.INTRODUCTION2
			update_labels()
		elif(currMode == MODE.INTRODUCTION2):
			currMode = MODE.EMPTYSTART
			update_labels()
		elif(currMode == MODE.EMPTYSTART):
			next_round()
			currMode = MODE.ROUNDBEGIN
			update_labels()
		elif(currMode == MODE.ROUNDBEGIN):
			currMode = MODE.QUESTION
			update_labels()
		elif(currMode == MODE.SHOWANSWERS):
			next_answer()
		elif(currMode == MODE.ANSWER):
			pass #next_question()
		elif(currMode == MODE.QUESTION):
			show_options()
		elif(currMode == MODE.ROUNDEND):
			currMode = MODE.SHOWANSWERS
			next_answer()
		elif(currMode == MODE.INBETWEEN):
			next_round()
			currMode = MODE.ROUNDBEGIN
			update_labels()
		else:
			print("what")
			breakpoint
#	else:
#		if Input.is_action_just_pressed("advance_round"):
#			next_round()
#		if Input.is_action_just_pressed("advance_question"):
#			show_options()
#		if Input.is_action_just_pressed("new_question"):
#			next_question()
	
	if Input.is_action_just_pressed("fullscreen"):
		if OS.window_fullscreen:
			OS.window_fullscreen = false
		else:
			OS.window_fullscreen = true
