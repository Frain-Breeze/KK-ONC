extends Node

var root

<<<<<<< HEAD
var ans1
var ans2
var ans3
var ans4

var cRound
var currQuestion = 0

func _ready():
	root = get_tree().get_root().get_node("main")
	root.connect("NEW_ROUND", self, "on_new_round")
	root.connect("NEW_QUESTION", self, "on_new_question")
	
	ans1 = get_node("answer1/text")
	ans2 = get_node("answer2/text")
	ans3 = get_node("answer3/text")
	ans4 = get_node("answer4/text")

func updateLabels():
	ans1.text = cRound.questions[currQuestion].answer1
	ans2.text = cRound.questions[currQuestion].answer2
	ans3.text = cRound.questions[currQuestion].answer3
	ans4.text = cRound.questions[currQuestion].answer4

func on_new_round(roundVar):
	#roundVar.questions.size()
	currQuestion = 0
	cRound = roundVar
	print("NEW ROUND TRIGGERED!")
	updateLabels()
	breakpoint


func on_new_question():
	currQuestion+=1
	ans1.text = "hallo"
=======
func _ready():
	root = get_tree().get_root().get_node("main")
>>>>>>> 65cef6e038f2bedb7eab2f8a6d036ba3f100d403
