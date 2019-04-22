public class Animal
{
    public string 编码 { get; set; }
    public AnimalKind 种类 { get; set; } //初始固定 读取Json
    public CurrentState 当前状态 { get; set; } //当前状态
    public int 年龄 { get; set; }         //变量 1开始
    public int 寿命 { get; set; }         //初始固定
    public int 发育期 { get; set; }        //初始固定 受胸围影响，成负相关
    public int 妊娠期 { get; set; }        //初始固定 受臀围影响，成负相关
    public float 身高 { get; set; }       //初始固定 读取Json范围
    public float 体重 { get; set; }       //初始固定 读取Json范围
    public float 胸围 { get; set; }       //初始固定 读取Json范围
    public float 腰围 { get; set; }       //初始固定 读取Json范围
    public float 臀围 { get; set; }       //初始固定 读取Json范围
    public float 魅力值 { get; set; }      //初始计算后得出，可以变化，影响金钱产出
    public FeedFood 食物种类 { get; set; }
    public int 消耗食物速度 { get; set; }    //初始固定 受腰围影响，成正相关

}
public enum CurrentState
{
    发育中, 可交配, 妊娠中
}
public enum AnimalKind
{
    兔娘
}
public enum FeedFood
{
    蔬菜, 肉
}