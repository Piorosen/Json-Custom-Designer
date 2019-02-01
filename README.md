# Customize Desginer

### defendency
Newtonsoft.Json

future :  
System.Text.Json

<hr />

## how to use?
1. Change Resize form
```
[{
	"Name": "Form1",
	"Property": [{
		"Name": "Size",
		"Constructor": {
			"System.Int32$0": "500",
			"System.Int32$1": "500"
		}
	}]
}]
```
2. Event Function Call
```
[{
	"Name": "Form1",
	"Field": [{
		"Name": "button2",
		"EventHandler": {
			"Name": "Click",
			"Method": "Write"
		}
	}]
}]
```
3. Text or Title Change
```
[{
	"Name": "Form1",
	"Field": [{
		"Name": "checkBox1",
		"Property": [{
			"Name": "Checked",
			"Type": "System.Boolean",
			"Value": "true"
		}]
	}, {
		"Name": "textBox3",
		"Property": [{
			"Name": "Text",
			"Type": "System.String",
			"Value": "123asd"
		}]
	}]
}]
```
4. Call Func
```
[{
	"Name": "Form1",
	"CallFunc": {
		"Name": "Write",
		"Param": {}
	}
}]
```
