<?php 
class task3{
  private $arr;
  public function __construct(){}
  //deserializaton json file
  public function deserializaton(){
    $fp = file_get_contents("items.json");
    $this->arr = json_decode($fp,true);
    return $this->arr;
  }
  //output the hierarchy in an array
  public function output($value,$count){
    foreach($value as $key=>$value2){
      if(is_array($value2)){
        echo str_repeat('-',$count).$key."<br>";
        $count2=$count+1;
        $this->output($value2,$count2);
      }
      else{
        echo str_repeat('-',$count).$value2."<br>";
      }
    }
  }
}
$app=new task3();
$arr=$app->deserializaton();
$app->output($arr,1);
?>