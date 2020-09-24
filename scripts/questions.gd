extends Node

var root

var ans1
var ans2
var ans3
var ans4
var quest

var cRound
var currQuestion = 0
var inAnswers = false

func _ready():
	root = get_tree().get_root().get_node("main")
	root.connect("NEW_ROUND", self, "on_new_round")
	root.connect("NEW_QUESTION", self, "on_new_question")
	root.connect("ADVANCE_ANSWER", self, "on_answer_advance")
	
	ans1 = get_node("answer1/text")
	ans2 = get_node("answer2/text")
	ans3 = get_node("answer3/text")
	ans4 = get_node("answer4/text")
	quest = get_node("question/text")

func updateLabels():
	if(cRound.questions.size() <= currQuestion):  #so we don't try to access questions that don't exist
			return
	if(inAnswers):
		quest.text = ""
		ans1.text = cRound.questions[currQuestion].answer1
		ans2.text = cRound.questions[currQuestion].answer2
		ans3.text = cRound.questions[currQuestion].answer3
		ans4.text = cRound.questions[currQuestion].answer4
	else: #we have to display the current question
		quest.text = cRound.questions[currQuestion].question
		ans1.text = ""
		ans2.text = ""
		ans3.text = ""
		ans4.text = ""

func on_new_round(roundVar):
	#roundVar.questions.size()
	currQuestion = 0
	cRound = roundVar
	print("NEW ROUND TRIGGERED!")
	updateLabels()

func on_new_question():
	if(cRound.questions.size() <= currQuestion):
		print("asked for a question that doesn't exist!")
		return;
	currQuestion+=1
	inAnswers = false
	updateLabels()

func on_answer_advance():
	inAnswers = true
	updateLabels()
