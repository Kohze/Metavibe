import React from 'react';
import { ScrollView, StyleSheet, View } from 'react-native';
import { Searchbar, Avatar, Button, Card, Title, Paragraph, Text } from 'react-native-paper';


export default class LinksScreen extends React.Component {

  state = {
    firstQuery: '',
    opdata: null,
    data: [],
  };

   static navigationOptions = {
    header: null,
  };

   async componentDidMount() {
    var b64 = "eyJ2IjozLCJxIjp7ImZpbmQiOnsib3V0LnMxIjoiTWV0YVZpYmUyIn0sImxpbWl0IjozMH19";
    var url = "https://genesis.bitdb.network/q/1FnauZ9aUH2Bex6JzdcV4eNX7oLSSEbxtN/eyJ2IjozLCJxIjp7ImZpbmQiOnsib3V0LmgxIjoiNGQ2NTc0NjE1NjY5NjI2NTQxNmM3MDY4NjEifSwibGltaXQiOjIwfX0=" + b64;
    var header = {
      headers: { key: "1KJPjd3p8khnWZTkjhDYnywLB2yE1w5BmU" }
    };

    const response = await fetch(url, header);
    const json = await response.json();
    this.setState({ data: json.c });
  }



  render() {



    const { firstQuery } = this.state;

    return (
    <ScrollView style={{backgroundColor: 'rgba(0,150,150,0.2)'}} >
       <Searchbar
          style={{margin: 3, marginTop: 30}}
          placeholder="Search"
          onChangeText={query => { this.setState({ firstQuery: query }); }}
          value={firstQuery}
       />

      <Card style={{margin: 3}}>
        <Card.Content style={{paddingBottom: 10}}>
          <Title>Park Meetup</Title>
          <Paragraph>20s meetup at the park at 16:00</Paragraph>
        </Card.Content>
        <Card.Cover source={{ uri: 'https://placeimg.com/640/480/nature?t=1557059912909' }} />
       </Card>

      {this.state.data && this.state.data.map((el,i) => (
           <Card style={{margin: 3}} key={i}>
            <Card.Content style={{paddingBottom: 10}}>
              <Title>{el.out[0].s2}</Title>
              <Paragraph>{el.out[0].s3}</Paragraph>
            </Card.Content>
           </Card>
      ))}

       
       <Card style={{margin: 3}}>
        <Card.Content style={{paddingBottom: 10}}>
          <Title>Trinity College Tour</Title>
          <Paragraph>I am giving tour for up to 4 persons at 15:00</Paragraph>
        </Card.Content>
        <Card.Cover source={{ uri: 'https://placeimg.com/640/480/arch?t=1557059841181' }} />
       </Card>

       <Card style={{margin: 3}}>
        <Card.Content style={{paddingBottom: 10}}>
          <Title>Football Evening</Title>
          <Paragraph>Watching the Champions League final</Paragraph>
        </Card.Content>
        <Card.Cover source={{ uri: 'https://placeimg.com/640/480/arch?t=1557059841188' }} />
       </Card>

            <Card style={{margin: 3}}>
        <Card.Content style={{paddingBottom: 10}}>
          <Title>Kings College Audio Guide</Title>
          <Paragraph>A audio guide from the world reknown historian Holgar King</Paragraph>
        </Card.Content>
        <Card.Cover source={{ uri: 'https://placeimg.com/640/480/arch?t=1557059841185' }} />
       </Card>

            <Card style={{margin: 3}}>
        <Card.Content style={{paddingBottom: 10}}>
          <Title>What just happened here?</Title>
          <Paragraph>Looks we just had a major accident just seconds ago</Paragraph>
        </Card.Content>
       </Card>

       <Card style={{margin: 3}}>
        <Card.Content style={{paddingBottom: 10}}>
          <Title>Climbing at Kelsey Kerridge</Title>
          <Paragraph>Weekly Bouldering at 17:00</Paragraph>
        </Card.Content>
        <Card.Cover source={{ uri: 'https://placeimg.com/640/480/arch?t=1557059841174' }} />
       </Card>
    </ScrollView>
    );
  }
}
