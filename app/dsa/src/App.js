import { Flex, Image, Text, Header, Button } from "@fluentui/react-northstar";
import D3Tree from "./d3tree/d3tree.js";
import { Layout } from "@fluentui/react-northstar";
import { Segment } from "@fluentui/react-northstar";
import { Provider, teamsTheme } from "@fluentui/react-northstar";
import { Menu } from "@fluentui/react-northstar";
import { CircleIcon } from "@fluentui/react-icons-northstar";

const items = [
  {
    key: "editorials",
    content: "Editorials",
    menu: {
      items: [
        {
          key: "1",
          content: "item1",
        },
        {
          key: "2",
          content: "item2",
          menu: [
            {
              key: "1",
              content: "item2.1",
            },
            {
              key: "2",
              content: "item2.2",
            },
          ],
        },
        {
          key: "3",
          content: "item3",
          menu: [
            {
              key: "1",
              content: "item3.1",
            },
            {
              key: "2",
              content: "item3.2",
            },
          ],
        },
      ],
    },
  },
  {
    key: "review",
    content: "Reviews",
    menu: {
      items: [
        {
          key: "1",
          content: "item1",
        },
        {
          key: "2",
          icon: <CircleIcon />,
          content: "item2 non augue tortor mollis",
          menu: [
            {
              key: "1",
              icon: <CircleIcon />,
              content: "item2.1",
            },
            {
              key: "2",
              content: "item2.2",
            },
          ],
        },
        {
          key: "3",
          icon: <CircleIcon />,
          content:
            "item3 elementum urna varius augue ultrices gravida malesuada fames",
          menu: [
            {
              key: "1",
              icon: <CircleIcon />,
              content: "item3.1",
            },
            {
              key: "2",
              content: "item3.2",
            },
          ],
        },
      ],
    },
  },
  {
    key: "events",
    content: "Upcoming Events",
  },
];

function App() {
  return (
    <Provider theme={teamsTheme}>
      <Flex.Item size="size.full">
        <Menu defaultActiveIndex={0} items={items} />
      </Flex.Item>
      <Flex gap="gap.small" padding="padding.medium">
        <Flex.Item size="size.full">
          <D3Tree></D3Tree>
        </Flex.Item>
      </Flex>
      <Flex gap="gap.small">
        <Button content="Accept" />
        <Button content="Deny" />
      </Flex>
    </Provider>
  );
}

export default App;
