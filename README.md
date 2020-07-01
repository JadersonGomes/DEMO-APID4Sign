<h3>About</h3>

<p>The D4Sign API is one of the many ways to use electronic signature to authenticate and sign documents with maximum security.</p>

<p>This is a test using and integrating them Web API to do requests and receive responses about the sign proccess. For this, I use C#, RestSharp to make requests and NewtonSoft to treat Json file. <p/>

<p>The objective of this project is clarify the integration with API's that can be used to accomplish and send documents for eletronic signature. The objective isn't explain how this API works.</P>

<h3>How to start?</h3>

<ul>
  <li>
    <p>First, you need to look at documention about how start to use D4Sign API on his website. You can do this accessing this link: http://docapi.d4sign.com.br</p>
  </li>
  
  
  <li>
    <p>After this, you need to create a demo account on his website to generate your tokenAPI and cryptKey. You can do it accessing this link: http://demo.d4sign.com.br/login</p>
  </li>
  
  <li>
    <p>With your tokenAPI and cryptKey, enter in GenericRepository class and insert the tokenAPI and cryptKey in the constructor of the class. </p>
  </li>
  
  <li>
    <p>Now, you need to install all project's dependency. So, you will install RestSharp to make requests and before you go install NewtonSoft.NET to treat all your responses on          Json format. </br></br>
       You can install those dependencys through console nuget package manager with those commands:
       <ul>
          <li>Install-Package RestSharp -Version 106.11.4</li>
          <li>Install-Package Newtonsoft.Json -Version 12.0.3</li>
       </ul>
    </p>
  </li>
  
   <li>
    <p>Before doing all last steps, you can create a GenericRepository instance and choose what method you want to use. All of methods returns a object and you can do anything          with this.</p>
  </li>
  
  
</ul>

</br></br></br>
  
<i  style="font-size:10px;">If you need some help, you can contact me on my email: jaderson_goomes@hotmail.com</i>
  
