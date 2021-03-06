import React from "react";
import Tree from "react-d3-tree";

// This is a simplified example of an org chart with a depth of 2.
// Note how deeper levels are defined recursively via the `children` property.
const orgChart = {
  name: "1",
  children: [
    {
      name: "2",
      children: [
        {
          name: "3",
          children: [
            {
              name: "9",
            },
          ],
        },
        {
          name: "4",
          children: [
            {
              name: "5",
            },
          ],
        },
      ],
    },
  ],
};

const point = {
  x: 700,
  y: 20,
};
export default function D3Tree() {
  return (
    // `<Tree />` will fill width/height of its container; in this case `#treeWrapper`.
    <div id="treeWrapper" style={{ width: "500em", height: "52em" }}>
      <Tree
        data={orgChart}
        pathFunc="straight"
        orientation="vertical"
        translate={point}
      ></Tree>
    </div>
  );
}
