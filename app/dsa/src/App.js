import logo from "./logo.svg";
import "./App.css";
import "./d3tree/d3tree.js";
import D3Tree from "./d3tree/d3tree.js";

function App() {
  return (
    <div className="App">
      <header className="App-header">
        <D3Tree></D3Tree>
      </header>
    </div>
  );
}

export default App;
