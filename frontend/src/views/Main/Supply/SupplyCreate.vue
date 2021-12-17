<template>
  <showcase-create v-bind="createData" />
</template>

<script>
import ShowcaseCreate from '@/components/Showcase/showcase-create'
import { required } from '@/utils/validation/i18n-validators'

export default {
  name: 'SupplyCreate',
  components: {
    ShowcaseCreate
  },
  data: () => {
    return {
      createData: {
        title: 'Создать поставку',
        fields: [
          {
            label: 'Поставщик',
            placeholder: 'Поставщик',
            modelValue: 'supplier',
            type: 'select',
            validation: { required },
            values: [
              {
                text: 'УтилПро',
                value: 1
              },
              {
                text: 'УтилМакс',
                value: 2
              }
            ]
          },
          {
            label: 'ТК',
            placeholder: 'ТК',
            modelValue: 'supplier',
            type: 'select',
            validation: { required },
            values: [
              {
                text: 'Автотрейд',
                value: 1
              },
              {
                text: 'КИТ',
                value: 2
              }
            ]
          },
          {
            label: 'Номер ТТН',
            placeholder: 'ТТН',
            modelValue: 'ttn',
            validation: { required }
          },
          {
            label: 'Номер платежного документа',
            placeholder: 'Номер платежного док',
            modelValue: 'paymentDoc',
            validation: { required }
          },
          {
            label: 'Стоимость поставки',
            placeholder: 'Стоимость',
            modelValue: 'supplyCost',
            validation: { required }
          },
          {
            label: 'Дата поставки',
            placeholder: 'Дада',
            modelValue: 'supplyDate',
            type: 'date',
            validation: { required }
          },
          {
            label: 'Примечание',
            placeholder: 'Примечание',
            modelValue: 'extra',
            type: 'textarea',
            cols: ['col-md-12']
          },
          {
            label: 'Принято',
            modelValue: 'accept',
            cols: ['col-auto'],
            type: 'checkbox'
          }
        ],
        enableAddedFields: true,
        subtitle: 'Товары на поставку',
        addedFields: [
          {
            label: 'Артикул',
            placeholder: 'Артикул',
            modelValue: 'art'
          },
          {
            label: 'Количество',
            placeholder: 'Кол-во',
            type: 'number',
            modelValue: 'count'
          }
        ]
      }
    }
  }
}
</script>
