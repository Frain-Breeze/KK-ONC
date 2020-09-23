extends Node

var root

func _ready():
	root = get_tree().get_root().get_node("main")
